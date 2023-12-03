//using Ghostscript.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS.Utils
{
    public static class PdfConvertor
    {
        //public static void PdfToImage(string InputPDFFile, int PageNumber, string outputPath)
        //{            
        //    GhostscriptPngDevice dev = new GhostscriptPngDevice(GhostscriptPngDeviceType.Png256);
        //    dev.GraphicsAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
        //    dev.TextAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
        //    dev.ResolutionXY = new GhostscriptImageDeviceResolution(290, 290);
        //    dev.InputFiles.Add(InputPDFFile);
        //    dev.Pdf.FirstPage = PageNumber;
        //    dev.Pdf.LastPage = PageNumber;
        //    dev.CustomSwitches.Add("-dDOINTERPOLATE");
        //    dev.OutputPath = outputPath;
        //    dev.Process();
        //}
    }
}
