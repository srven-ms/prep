public class Array
{
    // 733: https://leetcode.com/problems/flood-fill/description/
    public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        return FloodFillHelper(image, sr, sc, color, image[sr][sc]);
    }

    private static int[][] FloodFillHelper(int[][] image, int sr, int sc, int newColor, int oldColor)
    {
        if (image[sr][sc] == newColor)
        {
            return image;
        }

        if (image[sr][sc] == oldColor)
        {
            image[sr][sc] = newColor;
        }

        if (sr + 1 < image.Length && image[sr + 1][sc] == oldColor)
        {
            FloodFillHelper(image, sr + 1, sc, newColor, oldColor);
        }

        if (sr - 1 >= 0 && image[sr - 1][sc] == oldColor)
        {
            FloodFillHelper(image, sr - 1, sc, newColor, oldColor);
        }

        if (sc + 1 < image[0].Length && image[sr][sc + 1] == oldColor)
        {
            FloodFillHelper(image, sr, sc + 1, newColor, oldColor);
        }

        if (sc - 1 >= 0 && image[sr][sc - 1] == oldColor)
        {
            FloodFillHelper(image, sr, sc - 1, newColor, oldColor);
        }

        return image;
    }
}