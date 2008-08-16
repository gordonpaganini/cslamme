//-----------------------------------------------------------------------
//  Form for displaying WebCam video
//
//  $File: WebCamForm.cs $ $Revision: 1 $
//
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Microsoft.Robotics.Services.Dashboard
{
    // Windows Form for WebCam
    public partial class WebCamForm : Form
    {
        // This port is for communicating with the Dashboard
        // However, it is not currently used
        DashboardOperations _mainPort;

        public WebCamForm(DashboardOperations mainPort)
        {
            InitializeComponent();      // Required for a Windows Form
            _mainPort = mainPort;
        }

        private Bitmap _cameraImage;

        public Bitmap CameraImage
        {
            get { return _cameraImage; }
            set
            {
                _cameraImage = value;

                Image old = picCamera.Image;
                picCamera.Image = value;

                // Dispose of the old bitmap to save memory
                // (It will be garbage collected eventually, but this is faster)
                if (old != null)
                {
                    old.Dispose();
                }
            }
        }

    }
}