using System;
using ImageProcessing;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the target and template images
        string targetImagePath = "target.jpg"; // Replace with your target image path
        string templateImagePath = "template.jpg"; // Replace with your template image path

        try
        {
            // Call the template matching function
            var result = TemplateMatcher.FindTemplateLocation(targetImagePath, templateImagePath);

            // Output the results
            Console.WriteLine($"Template found at location: ({result.x}, {result.y})");
            Console.WriteLine($"Match quality score: {result.matchScore:P2}"); // Format as percentage

            // Optional: Add a threshold check for match quality
            double qualityThreshold = 0.8; // Example threshold (80%)
            if (result.matchScore < qualityThreshold)
            {
                Console.WriteLine("Warning: Low match quality. Template may not be accurately located.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}