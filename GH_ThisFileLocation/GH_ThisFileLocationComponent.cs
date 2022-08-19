using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

using System.IO;
using System.Diagnostics;
using System.Management.Instrumentation;
using Grasshopper.Kernel.Attributes;
using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;

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
            pManager.AddTextParameter("FilePath", "FilePath", "This gh definition file path", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //bool open = false;

            //if (!DA.GetData(0, ref open)) return;

            //GH_Document doc = this.OnPingDocument();
            //string filePath = doc.FilePath;
            //string filePathOnly = Path.GetDirectoryName(filePath);

            //if (open)
            //{
            //    try
            //    {
            //      Process.Start(filePathOnly);
            //    }
            //    catch(Exception e)
            //    {
            //        this.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, e.GetType().ToString());
            //    }

            //}


            DA.SetData(0, FilePathOnly());
        }

        public override void CreateAttributes()
        {
            m_attributes = new DoubleClick(this);
        }

        public string FilePathOnly()
        {
            GH_Document doc = this.OnPingDocument();
            string filePath = doc.FilePath;
            string filePathOnly = Path.GetDirectoryName(filePath);

            return filePathOnly;
        }

        public void OpenFolder()
        {
            var path = FilePathOnly();
            Process.Start(path);
        }

        public class DoubleClick : GH_ComponentAttributes
        {
            public DoubleClick(IGH_Component component) : base(component)
            {
            }

            public override GH_ObjectResponse RespondToMouseDoubleClick(GH_Canvas sender, GH_CanvasMouseEvent e)
            {
                (Owner as GH_ThisFileLocationComponent)?.OpenFolder();
                return GH_ObjectResponse.Handled;
            }
        }
        protected override System.Drawing.Bitmap Icon => Properties.Resources.folderIcon;

        public override Guid ComponentGuid => new Guid("F6C287F7-F6BF-4E49-AD6F-D0FAA8302AF8");
    }
}