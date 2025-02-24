using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ImageProcessing
{
    public class TemplateMatcher
    {
        /// <summary>
        /// Finds the location of a template image within a target image and returns the match quality score.
        /// </summary>
        /// <param name="targetImagePath">Path to the target image file.</param>
        /// <param name="templateImagePath">Path to the template image file.</param>
        /// <returns>A tuple containing the (x, y) location of the template and the match quality score.</returns>
        public static (int x, int y, double matchScore) FindTemplateLocation(string targetImagePath, string templateImagePath)
        {
            // Load the target image and template image
            using (Mat targetImage = CvInvoke.Imread(targetImagePath, ImreadModes.Color))
            using (Mat templateImage = CvInvoke.Imread(templateImagePath, ImreadModes.Color))
            {
                // Check if images are loaded successfully
                if (targetImage.IsEmpty || templateImage.IsEmpty)
                {
                    throw new Exception("Failed to load images.");
                }

                // Create a result matrix to store the matching result
                Mat result = new Mat();
                CvInvoke.MatchTemplate(targetImage, templateImage, result, TemplateMatchingType.CcoeffNormed);

                // Find the best match location and score
                double minVal = 0, maxVal = 0;
                System.Drawing.Point minLoc = new System.Drawing.Point();
                System.Drawing.Point maxLoc = new System.Drawing.Point();
                CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

                // Return the location of the best match and the match quality score
                return (maxLoc.X, maxLoc.Y, maxVal);
            }
        }
    }
}