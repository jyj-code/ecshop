using ShopNum1.QRCode.Codec;
using ShopNum1.QRCode.Codec.Reader;
using ShopNum1.QRCode.Codec.Util;
using ShopNum1.QRCode.ExceptionHandler;
using ShopNum1.QRCode.Geom;
using System;
using System.Collections;

namespace ShopNum1.QRCode.Codec.Reader.Pattern
{
    public class FinderPattern
    {
        public const int UL = 0;

        public const int UR = 1;

        public const int DL = 2;

        internal readonly static int[] VersionInfoBit;

        internal static DebugCanvas canvas;

        internal Point[] center;

        internal int version;

        internal int[] sincos;

        internal int[] width;

        internal int[] moduleSize;

        public virtual int SqrtNumModules
        {
            get
            {
                return 17 + 4 * this.version;
            }
        }

        public virtual int Version
        {
            get
            {
                return this.version;
            }
        }

        static FinderPattern()
        {
            FinderPattern.VersionInfoBit = new int[] { 31892, 34236, 39577, 42195, 48118, 51042, 55367, 58893, 63784, 68472, 70749, 76311, 79154, 84390, 87683, 92361, 96236, 102084, 102881, 110507, 110734, 117786, 119615, 126325, 127568, 133589, 136944, 141498, 145311, 150283, 152622, 158308, 161089, 167017 };
            FinderPattern.canvas = QRCodeDecoder.Canvas;
        }

        internal FinderPattern(Point[] center, int version, int[] sincos, int[] width, int[] moduleSize)
        {
            this.center = center;
            this.version = version;
            this.sincos = sincos;
            this.width = width;
            this.moduleSize = moduleSize;
        }

        internal static int calcExactVersion(Point[] centers, int[] angle, int[] moduleSize, bool[][] image)
        {
            Point point;
            int i;
            int j;
            bool[] flagArray = new bool[18];
            Point[] pointArray = new Point[18];
            Axis axi = new Axis(angle, moduleSize[1])
            {
                Origin = centers[1]
            };
            for (i = 0; i < 6; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    point = axi.translate(j - 7, i - 3);
                    flagArray[j + i * 3] = image[point.X][point.Y];
                    pointArray[j + i * 3] = point;
                }
            }
            FinderPattern.canvas.drawPoints(pointArray, Color_Fields.RED);
            int num = 0;
            try
            {
                num = FinderPattern.checkVersionInfo(flagArray);
            }
            catch (InvalidVersionInfoException invalidVersionInfoException)
            {
                FinderPattern.canvas.println("Version info error. now retry with other place one.");
                axi.Origin = centers[2];
                axi.ModulePitch = moduleSize[2];
                for (j = 0; j < 6; j++)
                {
                    for (i = 0; i < 3; i++)
                    {
                        point = axi.translate(j - 3, i - 7);
                        flagArray[i + j * 3] = image[point.X][point.Y];
                        pointArray[j + i * 3] = point;
                    }
                }
                FinderPattern.canvas.drawPoints(pointArray, Color_Fields.RED);
                try
                {
                    num = FinderPattern.checkVersionInfo(flagArray);
                }
                catch (VersionInformationException versionInformationException)
                {
                    throw versionInformationException;
                }
            }
            return num;
        }

        internal static int calcRoughVersion(Point[] center, int[] width)
        {
            int dECIMALPOINT = QRCodeImageReader.DECIMAL_POINT;
            int length = (new Line(center[0], center[1])).Length << (dECIMALPOINT & 31);
            int num = (width[0] + width[1] << (dECIMALPOINT & 31)) / 14;
            int num1 = (length / num - 10) / 4;
            if ((length / num - 10) % 4 >= 2)
            {
                num1++;
            }
            return num1;
        }

        internal static bool cantNeighbor(Line line1, Line line2)
        {
            bool flag;
            if (Line.isCross(line1, line2))
            {
                flag = true;
            }
            else if (!line1.Horizontal)
            {
                flag = (Math.Abs(line1.getP1().X - line2.getP1().X) <= 1 ? false : true);
            }
            else
            {
                flag = (Math.Abs(line1.getP1().Y - line2.getP1().Y) <= 1 ? false : true);
            }
            return flag;
        }

        internal static bool checkPattern(int[] buffer, int pointer)
        {
            bool flag;
            int[] numArray = new int[] { 1, 1, 3, 1, 1 };
            int dECIMALPOINT = 0;
            for (int i = 0; i < 5; i++)
            {
                dECIMALPOINT = dECIMALPOINT + buffer[i];
            }
            dECIMALPOINT = dECIMALPOINT << (QRCodeImageReader.DECIMAL_POINT & 31);
            dECIMALPOINT = dECIMALPOINT / 7;
            int num = 0;
            while (true)
            {
                if (num < 5)
                {
                    int num1 = dECIMALPOINT * numArray[num] - dECIMALPOINT / 2;
                    int num2 = dECIMALPOINT * numArray[num] + dECIMALPOINT / 2;
                    int num3 = buffer[(pointer + num + 1) % 5] << (QRCodeImageReader.DECIMAL_POINT & 31);
                    if ((num3 < num1 ? true : num3 > num2))
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        internal static int checkVersionInfo(bool[] target)
        {
            int i;
            int num = 0;
            for (i = 0; i < (int)FinderPattern.VersionInfoBit.Length; i++)
            {
                num = 0;
                for (int j = 0; j < 18; j++)
                {
                    if (target[j] ^ (FinderPattern.VersionInfoBit[i] >> (j & 31)) % 2 == 1)
                    {
                        num++;
                    }
                }
                if (num <= 3)
                {
                    break;
                }
            }
            if (num > 3)
            {
                throw new InvalidVersionInfoException("Too many errors in version information");
            }
            return 7 + i;
        }

        public static FinderPattern findFinderPattern(bool[][] image)
        {
            Line[] lineArray = FinderPattern.findLineCross(FinderPattern.findLineAcross(image));
            Point[] center = null;
            try
            {
                center = FinderPattern.getCenter(lineArray);
            }
            catch (FinderPatternNotFoundException finderPatternNotFoundException)
            {
                throw finderPatternNotFoundException;
            }
            int[] angle = FinderPattern.getAngle(center);
            center = FinderPattern.sort(center, angle);
            int[] width = FinderPattern.getWidth(image, center, angle);
            int[] dECIMALPOINT = new int[] { (width[0] << (QRCodeImageReader.DECIMAL_POINT & 31)) / 7, (width[1] << (QRCodeImageReader.DECIMAL_POINT & 31)) / 7, (width[2] << (QRCodeImageReader.DECIMAL_POINT & 31)) / 7 };
            int[] numArray = dECIMALPOINT;
            int num = FinderPattern.calcRoughVersion(center, width);
            if (num > 6)
            {
                try
                {
                    num = FinderPattern.calcExactVersion(center, angle, numArray, image);
                }
                catch (VersionInformationException versionInformationException)
                {
                }
            }
            return new FinderPattern(center, num, angle, width, numArray);
        }

        internal static Line[] findLineAcross(bool[][] image)
        {
            int x;
            int y;
            int num;
            int y1;
            int i;
            int num1 = 0;
            int num2 = 1;
            int length = (int)image.Length;
            int length1 = (int)image[0].Length;
            Point point = new Point();
            ArrayList arrayLists = ArrayList.Synchronized(new ArrayList(10));
            int[] numArray = new int[5];
            int num3 = 0;
            int num4 = 0;
            bool flag = false;
            while (true)
            {
                bool flag1 = image[point.X][point.Y];
                bool flag2 = flag1;
                if (flag1 != flag)
                {
                    if (!flag2 && FinderPattern.checkPattern(numArray, num3))
                    {
                        if (num4 != num1)
                        {
                            int x1 = point.X;
                            num = x1;
                            x = x1;
                            y = point.Y;
                            for (i = 0; i < 5; i++)
                            {
                                y = y - numArray[i];
                            }
                            y1 = point.Y - 1;
                        }
                        else
                        {
                            x = point.X;
                            for (i = 0; i < 5; i++)
                            {
                                x = x - numArray[i];
                            }
                            num = point.X - 1;
                            int y2 = point.Y;
                            y1 = y2;
                            y = y2;
                        }
                        arrayLists.Add(new Line(x, y, num, y1));
                    }
                    num3 = (num3 + 1) % 5;
                    numArray[num3] = 1;
                    flag = !flag;
                }
                else
                {
                    numArray[num3] = numArray[num3] + 1;
                }
                if (num4 != num1)
                {
                    if (point.Y >= length1 - 1)
                    {
                        if (point.X >= length - 1)
                        {
                            break;
                        }
                        point[point.X + 1] = 0;
                        numArray = new int[5];
                    }
                    else
                    {
                        point.translate(0, 1);
                    }
                }
                else if (point.X < length - 1)
                {
                    point.translate(1, 0);
                }
                else if (point.Y >= length1 - 1)
                {
                    point[0] = 0;
                    numArray = new int[5];
                    num4 = num2;
                }
                else
                {
                    point[0] = point.Y + 1;
                    numArray = new int[5];
                }
            }
            Line[] item = new Line[arrayLists.Count];
            for (int j = 0; j < (int)item.Length; j++)
            {
                item[j] = (Line)arrayLists[j];
            }
            FinderPattern.canvas.drawLines(item, Color_Fields.LIGHTGREEN);
            return item;
        }

        internal static Line[] findLineCross(Line[] lineAcross)
        {
            Line item;
            int i;
            int j;
            ArrayList arrayLists = ArrayList.Synchronized(new ArrayList(10));
            ArrayList arrayLists1 = ArrayList.Synchronized(new ArrayList(10));
            ArrayList arrayLists2 = ArrayList.Synchronized(new ArrayList(10));
            for (i = 0; i < (int)lineAcross.Length; i++)
            {
                arrayLists2.Add(lineAcross[i]);
            }
            for (i = 0; i < arrayLists2.Count - 1; i++)
            {
                arrayLists1.Clear();
                arrayLists1.Add(arrayLists2[i]);
                int num = i + 1;
                while (true)
                {
                    if (num < arrayLists2.Count)
                    {
                        if (Line.isNeighbor((Line)arrayLists1[arrayLists1.Count - 1], (Line)arrayLists2[num]))
                        {
                            arrayLists1.Add(arrayLists2[num]);
                            item = (Line)arrayLists1[arrayLists1.Count - 1];
                            if ((arrayLists1.Count * 5 <= item.Length ? false : num == arrayLists2.Count - 1))
                            {
                                arrayLists.Add(arrayLists1[arrayLists1.Count / 2]);
                                for (j = 0; j < arrayLists1.Count; j++)
                                {
                                    arrayLists2.Remove(arrayLists1[j]);
                                }
                            }
                        }
                        else if ((FinderPattern.cantNeighbor((Line)arrayLists1[arrayLists1.Count - 1], (Line)arrayLists2[num]) ? true : num == arrayLists2.Count - 1))
                        {
                            item = (Line)arrayLists1[arrayLists1.Count - 1];
                            if (arrayLists1.Count * 6 <= item.Length)
                            {
                                break;
                            }
                            arrayLists.Add(arrayLists1[arrayLists1.Count / 2]);
                            for (j = 0; j < arrayLists1.Count; j++)
                            {
                                arrayLists2.Remove(arrayLists1[j]);
                            }
                            //goto Label0;
                        }
                        num++;
                    }
                    else
                    {
                        break;
                    }
                }
                //Label0:
            }
            Line[] lineArray = new Line[arrayLists.Count];
            for (i = 0; i < (int)lineArray.Length; i++)
            {
                lineArray[i] = (Line)arrayLists[i];
            }
            return lineArray;
        }

        public virtual int[] getAngle()
        {
            return this.sincos;
        }

        internal static int[] getAngle(Point[] centers)
        {
            int i;
            Line[] line = new Line[3];
            for (i = 0; i < (int)line.Length; i++)
            {
                line[i] = new Line(centers[i], centers[(i + 1) % (int)line.Length]);
            }
            Line longest = Line.getLongest(line);
            Point point = new Point();
            i = 0;
            while (true)
            {
                if (i >= (int)centers.Length)
                {
                    break;
                }
                else if ((longest.getP1().equals(centers[i]) ? false : !longest.getP2().equals(centers[i])))
                {
                    point = centers[i];
                    break;
                }
                else
                {
                    i++;
                }
            }
            FinderPattern.canvas.println(string.Concat("originPoint is: ", point));
            Point point1 = new Point();
            if (point.Y <= longest.getP1().Y & point.Y <= longest.getP2().Y)
            {
                point1 = (longest.getP1().X >= longest.getP2().X ? longest.getP1() : longest.getP2());
            }
            else if (point.X >= longest.getP1().X & point.X >= longest.getP2().X)
            {
                point1 = (longest.getP1().Y >= longest.getP2().Y ? longest.getP1() : longest.getP2());
            }
            else if (!(point.Y >= longest.getP1().Y & point.Y >= longest.getP2().Y))
            {
                point1 = (longest.getP1().Y >= longest.getP2().Y ? longest.getP2() : longest.getP1());
            }
            else
            {
                point1 = (longest.getP1().X >= longest.getP2().X ? longest.getP2() : longest.getP1());
            }
            int length = (new Line(point, point1)).Length;
            int[] y = new int[] { (point1.Y - point.Y << (QRCodeImageReader.DECIMAL_POINT & 31)) / length, (point1.X - point.X << (QRCodeImageReader.DECIMAL_POINT & 31)) / length };
            return y;
        }

        public virtual Point[] getCenter()
        {
            return this.center;
        }

        public virtual Point getCenter(int position)
        {
            Point point;
            if ((position < 0 ? true : position > 2))
            {
                point = null;
            }
            else
            {
                point = this.center[position];
            }
            return point;
        }

        internal static Point[] getCenter(Line[] crossLines)
        {
            int i;
            ArrayList arrayLists = ArrayList.Synchronized(new ArrayList(10));
            for (i = 0; i < (int)crossLines.Length - 1; i++)
            {
                Line line = crossLines[i];
                for (int j = i + 1; j < (int)crossLines.Length; j++)
                {
                    Line line1 = crossLines[j];
                    if (Line.isCross(line, line1))
                    {
                        int x = 0;
                        int y = 0;
                        if (!line.Horizontal)
                        {
                            x = line1.Center.X;
                            y = line.Center.Y;
                        }
                        else
                        {
                            x = line.Center.X;
                            y = line1.Center.Y;
                        }
                        arrayLists.Add(new Point(x, y));
                    }
                }
            }
            Point[] item = new Point[arrayLists.Count];
            for (i = 0; i < (int)item.Length; i++)
            {
                item[i] = (Point)arrayLists[i];
            }
            if ((int)item.Length != 3)
            {
                throw new FinderPatternNotFoundException("Invalid number of Finder Pattern detected");
            }
            FinderPattern.canvas.drawPolygon(item, Color_Fields.RED);
            return item;
        }

        public virtual int getModuleSize()
        {
            return this.moduleSize[0];
        }

        public virtual int getModuleSize(int place)
        {
            return this.moduleSize[place];
        }

        internal static Point getPointAtSide(Point[] points, int side1, int side2)
        {
            Point point = new Point();
            int num = (side1 == 1 || side2 == 1 ? 0 : 2147483647);
            point = new Point(num, (side1 == 2 || side2 == 2 ? 0 : 2147483647));
            int num1 = 0;
            while (num1 < (int)points.Length)
            {
                int num2 = side1;
                switch (num2)
                {
                    case 1:
                        {
                            if (point.X >= points[num1].X)
                            {
                                if (point.X != points[num1].X)
                                {
                                    goto case 3;
                                }
                                if (side2 != 2)
                                {
                                    if (point.Y <= points[num1].Y)
                                    {
                                        goto case 3;
                                    }
                                    point = points[num1];
                                    goto case 3;
                                }
                                else
                                {
                                    if (point.Y >= points[num1].Y)
                                    {
                                        goto case 3;
                                    }
                                    point = points[num1];
                                    goto case 3;
                                }
                            }
                            else
                            {
                                point = points[num1];
                                goto case 3;
                            }
                        }
                    case 2:
                        {
                            if (point.Y >= points[num1].Y)
                            {
                                if (point.Y != points[num1].Y)
                                {
                                    goto case 3;
                                }
                                if (side2 != 1)
                                {
                                    if (point.X <= points[num1].X)
                                    {
                                        goto case 3;
                                    }
                                    point = points[num1];
                                    goto case 3;
                                }
                                else
                                {
                                    if (point.X >= points[num1].X)
                                    {
                                        goto case 3;
                                    }
                                    point = points[num1];
                                    goto case 3;
                                }
                            }
                            else
                            {
                                point = points[num1];
                                goto case 3;
                            }
                        }
                    case 3:
                        {
                            num1++;
                            continue;
                        }
                    case 4:
                        {
                            if (point.X <= points[num1].X)
                            {
                                if (point.X != points[num1].X)
                                {
                                    goto case 3;
                                }
                                if (side2 != 2)
                                {
                                    if (point.Y <= points[num1].Y)
                                    {
                                        goto case 3;
                                    }
                                    point = points[num1];
                                    goto case 3;
                                }
                                else
                                {
                                    if (point.Y >= points[num1].Y)
                                    {
                                        goto case 3;
                                    }
                                    point = points[num1];
                                    goto case 3;
                                }
                            }
                            else
                            {
                                point = points[num1];
                                goto case 3;
                            }
                        }
                    default:
                        {
                            if (num2 != 8)
                            {
                                goto case 3;
                            }
                            else if (point.Y <= points[num1].Y)
                            {
                                if (point.Y != points[num1].Y)
                                {
                                    goto case 3;
                                }
                                if (side2 != 1)
                                {
                                    if (point.X <= points[num1].X)
                                    {
                                        goto case 3;
                                    }
                                    point = points[num1];
                                    goto case 3;
                                }
                                else
                                {
                                    if (point.X >= points[num1].X)
                                    {
                                        goto case 3;
                                    }
                                    point = points[num1];
                                    goto case 3;
                                }
                            }
                            else
                            {
                                point = points[num1];
                                goto case 3;
                            }
                        }
                }
            }
            return point;
        }

        internal static int getURQuadant(int[] angle)
        {
            int num;
            int num1 = angle[0];
            int num2 = angle[1];
            if (!(num1 < 0 ? true : num2 <= 0))
            {
                num = 1;
            }
            else if (!(num1 <= 0 ? true : num2 > 0))
            {
                num = 2;
            }
            else if ((num1 > 0 ? true : num2 >= 0))
            {
                num = ((num1 >= 0 ? true : num2 < 0) ? 0 : 4);
            }
            else
            {
                num = 3;
            }
            return num;
        }

        public virtual int getWidth(int position)
        {
            return this.width[position];
        }

        internal static int[] getWidth(bool[][] image, Point[] centers, int[] sincos)
        {
            int j;
            int k;
            int[] numArray = new int[3];
            for (int i = 0; i < 3; i++)
            {
                bool flag = false;
                int y = centers[i].Y;
                for (j = centers[i].X; j > 0; j--)
                {
                    if ((!image[j][y] ? false : !image[j - 1][y]))
                    {
                        if (flag)
                        {
                            break;
                        }
                        flag = true;
                    }
                }
                flag = false;
                for (k = centers[i].X; k < (int)image.Length; k++)
                {
                    if ((!image[k][y] ? false : !image[k + 1][y]))
                    {
                        if (flag)
                        {
                            break;
                        }
                        flag = true;
                    }
                }
                numArray[i] = k - j + 1;
            }
            return numArray;
        }

        internal static Point[] sort(Point[] centers, int[] angle)
        {
            Point[] pointAtSide = new Point[3];
            switch (FinderPattern.getURQuadant(angle))
            {
                case 1:
                    {
                        pointAtSide[1] = FinderPattern.getPointAtSide(centers, 1, 2);
                        pointAtSide[2] = FinderPattern.getPointAtSide(centers, 2, 4);
                        break;
                    }
                case 2:
                    {
                        pointAtSide[1] = FinderPattern.getPointAtSide(centers, 2, 4);
                        pointAtSide[2] = FinderPattern.getPointAtSide(centers, 8, 4);
                        break;
                    }
                case 3:
                    {
                        pointAtSide[1] = FinderPattern.getPointAtSide(centers, 4, 8);
                        pointAtSide[2] = FinderPattern.getPointAtSide(centers, 1, 8);
                        break;
                    }
                case 4:
                    {
                        pointAtSide[1] = FinderPattern.getPointAtSide(centers, 8, 1);
                        pointAtSide[2] = FinderPattern.getPointAtSide(centers, 2, 1);
                        break;
                    }
            }
            for (int i = 0; i < (int)centers.Length; i++)
            {
                if ((centers[i].equals(pointAtSide[1]) ? false : !centers[i].equals(pointAtSide[2])))
                {
                    pointAtSide[0] = centers[i];
                }
            }
            return pointAtSide;
        }
    }
}