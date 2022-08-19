using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace GH_ThisFileLocation
{
    public class GH_ThisFileLocationInfo : GH_AssemblyInfo
    {
        public override string Name => "GH_ThisFileLocation";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "This gh definition filepath";

        public override Guid Id => new Guid("D7A1CCF3-286B-42CD-8B44-6FE0441D7C64");

        //Return a string identifying you or your company.
        public override string AuthorName => "masaya TAKATA";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "https://github.com/masayaTAKATA";
    }
}