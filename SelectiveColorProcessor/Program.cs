using System.Drawing;

namespace SelectiveColorProcessor
{
    class Program
    {
        static Bitmap ConvertTheBitmap(Bitmap img, Color rangeColor, int t)
        {
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color currentPixel = img.GetPixel(x, y);
                    if (!ColorInRange(currentPixel, rangeColor, t))
                    {
                        int grayValue = (currentPixel.R + currentPixel.G + currentPixel.B) / 3;
                        Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                        img.SetPixel(x, y, grayColor);
                    }
                }
            }

            return img;
        }

        static bool ColorInRange(Color currentPixel, Color selectedColor, int threshHold)
        {
            bool inRange = true;

            if (currentPixel.R < (selectedColor.R - threshHold)) inRange = false;
            if (currentPixel.R > (selectedColor.R + threshHold)) inRange = false;
            if (currentPixel.G < (selectedColor.G - threshHold)) inRange = false;
            if (currentPixel.G > (selectedColor.G + threshHold)) inRange = false;
            if (currentPixel.B < (selectedColor.B - threshHold)) inRange = false;
            if (currentPixel.B > (selectedColor.B + threshHold)) inRange = false;

            return inRange;
        }

        static void Main(string[] args)
        {
            Bitmap img = new Bitmap(args[0]);
            Color rangeColor = new Color();
            int R, G, B, t;
            int.TryParse(args[1], out R);
            int.TryParse(args[2], out G);
            int.TryParse(args[3], out B);
            int.TryParse(args[4], out t);
            rangeColor = Color.FromArgb(R,G,B);
            Bitmap newImage = ConvertTheBitmap(img, rangeColor, t);
            newImage.Save(args[5]);
        }
    }

}
