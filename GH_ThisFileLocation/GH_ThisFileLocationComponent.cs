using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

using System.IO;

namespace GH_ThisFileLocation
{
    public class GH_ThisFileLocationComponent : GH_Component
    {
        public GH_ThisFileLocationComponent()
          : base("GH_ThisFileLocation", "Here",
            "This gh definition filepath",
            "Maths", "Script")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("FilePath", "Path", "This gh definition file path", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            GH_Document doc = this.OnPingDocument();
            string filePath = doc.FilePath;
            string filePathOnly = Path.GetDirectoryName(filePath);

            DA.SetData(0, filePathOnly);
        }

        protected override System.Drawing.Bitmap Icon => Properties.Resources.folderIcon;

        public override Guid ComponentGuid => new Guid("F6C287F7-F6BF-4E49-AD6F-D0FAA8302AF8");
    }
}