//-----------------------------------------------------------------------
//  This file is part of the Microsoft Robotics Studio Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  $File: DriveControl.Designer.cs $ $Revision: 9 $
//-----------------------------------------------------------------------

namespace Cranium.Controls
{
    partial class DriveControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label lblActiveJoint;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriveControl));
            this.cbJoystick = new System.Windows.Forms.ComboBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblButtons = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStop = new System.Windows.Forms.CheckBox();
            this.chkDrive = new System.Windows.Forms.CheckBox();
            this.picJoystick = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkDirectory = new System.Windows.Forms.LinkLabel();
            this.lblNode = new System.Windows.Forms.Label();
            this.listDirectory = new System.Windows.Forms.ListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.MaskedTextBox();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.groupBoxLRF = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblDelay = new System.Windows.Forms.Label();
            this.btnConnectLRF = new System.Windows.Forms.Button();
            this.btnStartLRF = new System.Windows.Forms.Button();
            this.picLRF = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.lblLag = new System.Windows.Forms.Label();
            this.lblMotor = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxArm = new System.Windows.Forms.GroupBox();
            this.lblActiveJointValue = new System.Windows.Forms.Label();
            this.listArticulatedArmJoints = new System.Windows.Forms.ListBox();
            this.btnConnect_ArticulatedArm = new System.Windows.Forms.Button();
            this.btnJointParamsApply = new System.Windows.Forms.Button();
            this.textBoxJointAngle = new System.Windows.Forms.TextBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SonarGroupBox = new System.Windows.Forms.GroupBox();
            this.lblSonarS7 = new System.Windows.Forms.Label();
            this.lblSonarS6 = new System.Windows.Forms.Label();
            this.lblSonarS5 = new System.Windows.Forms.Label();
            this.lblSonarS4 = new System.Windows.Forms.Label();
            this.lblSonarS3 = new System.Windows.Forms.Label();
            this.lblSonarS2 = new System.Windows.Forms.Label();
            this.lblSonarS1 = new System.Windows.Forms.Label();
            this.lblSonarS0 = new System.Windows.Forms.Label();
            this.btnStartSonar = new System.Windows.Forms.Button();
            this.picSonar = new System.Windows.Forms.PictureBox();
            this.btnDisconnectSonar = new System.Windows.Forms.Button();
            this.btnConnectSonar = new System.Windows.Forms.Button();
            this.lblSonarDelay = new System.Windows.Forms.Label();
            this.grBoxSonarMap = new System.Windows.Forms.GroupBox();
            this.btnCamDisconnect = new System.Windows.Forms.Button();
            this.btnCamConnect = new System.Windows.Forms.Button();
            this.picCamImage = new System.Windows.Forms.PictureBox();
            this.groupBoxVision = new System.Windows.Forms.GroupBox();
            this.picVisionObject = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.picVisionFace = new System.Windows.Forms.PictureBox();
            this.picRightHand = new System.Windows.Forms.PictureBox();
            this.picLeftHand = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnDisconnectVision = new System.Windows.Forms.Button();
            this.btnConnectVision = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.picMotion = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            lblActiveJoint = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJoystick)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxLRF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLRF)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBoxArm.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SonarGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSonar)).BeginInit();
            this.grBoxSonarMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamImage)).BeginInit();
            this.groupBoxVision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVisionObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisionFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMotion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 13);
            label1.TabIndex = 1;
            label1.Text = "Device:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(34, 50);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(17, 13);
            label5.TabIndex = 5;
            label5.Text = "X:";
            label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(34, 67);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(17, 13);
            label6.TabIndex = 6;
            label6.Text = "Y:";
            label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(34, 84);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(17, 13);
            label7.TabIndex = 7;
            label7.Text = "Z:";
            label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 101);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 13);
            label2.TabIndex = 8;
            label2.Text = "Buttons:";
            label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 50);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(29, 13);
            label4.TabIndex = 1;
            label4.Text = "Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 20);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 13);
            label3.TabIndex = 0;
            label3.Text = "Machine:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(14, 17);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(37, 13);
            label8.TabIndex = 16;
            label8.Text = "Motor:";
            label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(23, 34);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(28, 13);
            label10.TabIndex = 18;
            label10.Text = "Lag:";
            label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(96, 62);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(37, 13);
            label9.TabIndex = 18;
            label9.Text = "Angle:";
            label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblActiveJoint
            // 
            lblActiveJoint.AutoSize = true;
            lblActiveJoint.Location = new System.Drawing.Point(96, 22);
            lblActiveJoint.Name = "lblActiveJoint";
            lblActiveJoint.Size = new System.Drawing.Size(65, 13);
            lblActiveJoint.TabIndex = 24;
            lblActiveJoint.Text = "Active Joint:";
            lblActiveJoint.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbJoystick
            // 
            this.cbJoystick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbJoystick.FormattingEnabled = true;
            this.cbJoystick.Location = new System.Drawing.Point(60, 22);
            this.cbJoystick.Name = "cbJoystick";
            this.cbJoystick.Size = new System.Drawing.Size(129, 21);
            this.cbJoystick.TabIndex = 0;
            this.cbJoystick.SelectedIndexChanged += new System.EventHandler(this.cbJoystick_SelectedIndexChanged);
            // 
            // lblX
            // 
            this.lblX.Location = new System.Drawing.Point(60, 50);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(35, 13);
            this.lblX.TabIndex = 2;
            this.lblX.Text = "0";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY
            // 
            this.lblY.Location = new System.Drawing.Point(60, 67);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(35, 13);
            this.lblY.TabIndex = 3;
            this.lblY.Text = "0";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ
            // 
            this.lblZ.Location = new System.Drawing.Point(60, 84);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(35, 13);
            this.lblZ.TabIndex = 4;
            this.lblZ.Text = "0";
            this.lblZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblButtons
            // 
            this.lblButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblButtons.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblButtons.Location = new System.Drawing.Point(63, 101);
            this.lblButtons.Name = "lblButtons";
            this.lblButtons.Size = new System.Drawing.Size(126, 13);
            this.lblButtons.TabIndex = 9;
            this.lblButtons.Text = "O";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkStop);
            this.groupBox1.Controls.Add(this.chkDrive);
            this.groupBox1.Controls.Add(this.picJoystick);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.lblButtons);
            this.groupBox1.Controls.Add(this.cbJoystick);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.lblX);
            this.groupBox1.Controls.Add(label7);
            this.groupBox1.Controls.Add(this.lblY);
            this.groupBox1.Controls.Add(label6);
            this.groupBox1.Controls.Add(this.lblZ);
            this.groupBox1.Controls.Add(label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 151);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direct Input Device";
            // 
            // chkStop
            // 
            this.chkStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkStop.Location = new System.Drawing.Point(112, 117);
            this.chkStop.Name = "chkStop";
            this.chkStop.Size = new System.Drawing.Size(77, 24);
            this.chkStop.TabIndex = 12;
            this.chkStop.Text = "Stop";
            this.chkStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStop.UseVisualStyleBackColor = true;
            this.chkStop.CheckedChanged += new System.EventHandler(this.chkStop_CheckedChanged);
            // 
            // chkDrive
            // 
            this.chkDrive.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDrive.Location = new System.Drawing.Point(9, 117);
            this.chkDrive.Name = "chkDrive";
            this.chkDrive.Size = new System.Drawing.Size(76, 24);
            this.chkDrive.TabIndex = 11;
            this.chkDrive.Text = "Drive";
            this.chkDrive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDrive.UseVisualStyleBackColor = true;
            // 
            // picJoystick
            // 
            this.picJoystick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picJoystick.Location = new System.Drawing.Point(129, 49);
            this.picJoystick.Name = "picJoystick";
            this.picJoystick.Size = new System.Drawing.Size(49, 49);
            this.picJoystick.TabIndex = 10;
            this.picJoystick.TabStop = false;
            this.picJoystick.MouseLeave += new System.EventHandler(this.picJoystick_MouseLeave);
            this.picJoystick.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picJoystick_MouseMove);
            this.picJoystick.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picJoystick_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.linkDirectory);
            this.groupBox2.Controls.Add(this.lblNode);
            this.groupBox2.Controls.Add(this.listDirectory);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.txtMachine);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Location = new System.Drawing.Point(213, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 220);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remote Node";
            // 
            // linkDirectory
            // 
            this.linkDirectory.AutoSize = true;
            this.linkDirectory.Enabled = false;
            this.linkDirectory.LinkArea = new System.Windows.Forms.LinkArea(8, 9);
            this.linkDirectory.Location = new System.Drawing.Point(7, 75);
            this.linkDirectory.Name = "linkDirectory";
            this.linkDirectory.Size = new System.Drawing.Size(94, 17);
            this.linkDirectory.TabIndex = 8;
            this.linkDirectory.TabStop = true;
            this.linkDirectory.Text = "Service Directory:";
            this.linkDirectory.UseCompatibleTextRendering = true;
            this.linkDirectory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDirectory_LinkClicked);
            // 
            // lblNode
            // 
            this.lblNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNode.AutoEllipsis = true;
            this.lblNode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNode.Location = new System.Drawing.Point(10, 96);
            this.lblNode.Name = "lblNode";
            this.lblNode.Size = new System.Drawing.Size(154, 20);
            this.lblNode.TabIndex = 7;
            // 
            // listDirectory
            // 
            this.listDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listDirectory.FormattingEnabled = true;
            this.listDirectory.Location = new System.Drawing.Point(10, 132);
            this.listDirectory.Name = "listDirectory";
            this.listDirectory.Size = new System.Drawing.Size(157, 82);
            this.listDirectory.TabIndex = 5;
            this.listDirectory.DoubleClick += new System.EventHandler(this.listDirectory_DoubleClick);
            this.listDirectory.SelectedIndexChanged += new System.EventHandler(this.listDirectory_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(112, 42);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(55, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(64, 44);
            this.txtPort.Mask = "99999";
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(42, 20);
            this.txtPort.TabIndex = 3;
            // 
            // txtMachine
            // 
            this.txtMachine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachine.Location = new System.Drawing.Point(64, 17);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(103, 20);
            this.txtMachine.TabIndex = 2;
            // 
            // groupBoxLRF
            // 
            this.groupBoxLRF.Controls.Add(this.btnDisconnect);
            this.groupBoxLRF.Controls.Add(this.lblDelay);
            this.groupBoxLRF.Controls.Add(this.btnConnectLRF);
            this.groupBoxLRF.Controls.Add(this.btnStartLRF);
            this.groupBoxLRF.Controls.Add(this.picLRF);
            this.groupBoxLRF.Location = new System.Drawing.Point(12, 320);
            this.groupBoxLRF.Name = "groupBoxLRF";
            this.groupBoxLRF.Size = new System.Drawing.Size(374, 175);
            this.groupBoxLRF.TabIndex = 12;
            this.groupBoxLRF.TabStop = false;
            this.groupBoxLRF.Text = "Laser Range Finder";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(168, 19);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lblDelay
            // 
            this.lblDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelay.Location = new System.Drawing.Point(262, 23);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(103, 18);
            this.lblDelay.TabIndex = 3;
            this.lblDelay.Text = "0";
            // 
            // btnConnectLRF
            // 
            this.btnConnectLRF.Enabled = false;
            this.btnConnectLRF.Location = new System.Drawing.Point(87, 19);
            this.btnConnectLRF.Name = "btnConnectLRF";
            this.btnConnectLRF.Size = new System.Drawing.Size(75, 23);
            this.btnConnectLRF.TabIndex = 2;
            this.btnConnectLRF.Text = "Connect";
            this.btnConnectLRF.UseVisualStyleBackColor = true;
            this.btnConnectLRF.Click += new System.EventHandler(this.btnConnectLRF_Click);
            // 
            // btnStartLRF
            // 
            this.btnStartLRF.Enabled = false;
            this.btnStartLRF.Location = new System.Drawing.Point(6, 18);
            this.btnStartLRF.Name = "btnStartLRF";
            this.btnStartLRF.Size = new System.Drawing.Size(75, 23);
            this.btnStartLRF.TabIndex = 1;
            this.btnStartLRF.Text = "Start";
            this.btnStartLRF.UseVisualStyleBackColor = true;
            this.btnStartLRF.Click += new System.EventHandler(this.btnStartLRF_Click);
            // 
            // picLRF
            // 
            this.picLRF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picLRF.Location = new System.Drawing.Point(7, 48);
            this.picLRF.Name = "picLRF";
            this.picLRF.Size = new System.Drawing.Size(361, 121);
            this.picLRF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLRF.TabIndex = 0;
            this.picLRF.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btnReverse);
            this.groupBox4.Controls.Add(this.btnStop);
            this.groupBox4.Controls.Add(this.btnForward);
            this.groupBox4.Controls.Add(this.btnRight);
            this.groupBox4.Controls.Add(this.btnLeft);
            this.groupBox4.Controls.Add(label10);
            this.groupBox4.Controls.Add(this.lblLag);
            this.groupBox4.Controls.Add(label8);
            this.groupBox4.Controls.Add(this.lblMotor);
            this.groupBox4.Location = new System.Drawing.Point(12, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 140);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Differential Drive";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(9, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 30);
            this.label11.TabIndex = 24;
            this.label11.Text = "Motion Control\r\n(See Options)";
            // 
            // btnReverse
            // 
            this.btnReverse.Enabled = false;
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.Location = new System.Drawing.Point(112, 96);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(32, 32);
            this.btnReverse.TabIndex = 23;
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(112, 58);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(32, 32);
            this.btnStop.TabIndex = 22;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnForward
            // 
            this.btnForward.Enabled = false;
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.Location = new System.Drawing.Point(112, 20);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(32, 32);
            this.btnForward.TabIndex = 21;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnRight
            // 
            this.btnRight.Enabled = false;
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.Location = new System.Drawing.Point(150, 58);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(32, 32);
            this.btnRight.TabIndex = 20;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Enabled = false;
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.Location = new System.Drawing.Point(74, 58);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(32, 32);
            this.btnLeft.TabIndex = 19;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // lblLag
            // 
            this.lblLag.Location = new System.Drawing.Point(60, 34);
            this.lblLag.Name = "lblLag";
            this.lblLag.Size = new System.Drawing.Size(35, 13);
            this.lblLag.TabIndex = 17;
            this.lblLag.Text = "0";
            this.lblLag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMotor
            // 
            this.lblMotor.Location = new System.Drawing.Point(60, 17);
            this.lblMotor.Name = "lblMotor";
            this.lblMotor.Size = new System.Drawing.Size(35, 13);
            this.lblMotor.TabIndex = 15;
            this.lblMotor.Text = "Off";
            this.lblMotor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.btnBrowse);
            this.groupBox5.Controls.Add(this.txtLogFile);
            this.groupBox5.Controls.Add(this.chkLog);
            this.groupBox5.Location = new System.Drawing.Point(213, 250);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(173, 70);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Logging";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(106, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 18);
            this.label12.TabIndex = 18;
            this.label12.Text = "0";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(140, 42);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtLogFile
            // 
            this.txtLogFile.Location = new System.Drawing.Point(6, 43);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.Size = new System.Drawing.Size(128, 20);
            this.txtLogFile.TabIndex = 1;
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(6, 19);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(95, 17);
            this.chkLog.TabIndex = 0;
            this.chkLog.Text = "Log Messages";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Xml log file|*.log;*.xml|All files|*.*";
            this.saveFileDialog.Title = "Log File";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // groupBoxArm
            // 
            this.groupBoxArm.Controls.Add(this.lblActiveJointValue);
            this.groupBoxArm.Controls.Add(lblActiveJoint);
            this.groupBoxArm.Controls.Add(this.listArticulatedArmJoints);
            this.groupBoxArm.Controls.Add(this.btnConnect_ArticulatedArm);
            this.groupBoxArm.Controls.Add(this.btnJointParamsApply);
            this.groupBoxArm.Controls.Add(this.textBoxJointAngle);
            this.groupBoxArm.Controls.Add(label9);
            this.groupBoxArm.Location = new System.Drawing.Point(12, 500);
            this.groupBoxArm.Name = "groupBoxArm";
            this.groupBoxArm.Size = new System.Drawing.Size(374, 96);
            this.groupBoxArm.TabIndex = 15;
            this.groupBoxArm.TabStop = false;
            this.groupBoxArm.Text = "Articulated Arm";
            // 
            // lblActiveJointValue
            // 
            this.lblActiveJointValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActiveJointValue.Location = new System.Drawing.Point(96, 38);
            this.lblActiveJointValue.Name = "lblActiveJointValue";
            this.lblActiveJointValue.Size = new System.Drawing.Size(75, 18);
            this.lblActiveJointValue.TabIndex = 25;
            this.lblActiveJointValue.Text = "None";
            // 
            // listArticulatedArmJoints
            // 
            this.listArticulatedArmJoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listArticulatedArmJoints.FormattingEnabled = true;
            this.listArticulatedArmJoints.Location = new System.Drawing.Point(211, 20);
            this.listArticulatedArmJoints.Name = "listArticulatedArmJoints";
            this.listArticulatedArmJoints.Size = new System.Drawing.Size(157, 56);
            this.listArticulatedArmJoints.TabIndex = 23;
            this.listArticulatedArmJoints.DoubleClick += new System.EventHandler(this.listArticulatedArmJointList_DoubleClick);
            // 
            // btnConnect_ArticulatedArm
            // 
            this.btnConnect_ArticulatedArm.Enabled = false;
            this.btnConnect_ArticulatedArm.Location = new System.Drawing.Point(6, 20);
            this.btnConnect_ArticulatedArm.Name = "btnConnect_ArticulatedArm";
            this.btnConnect_ArticulatedArm.Size = new System.Drawing.Size(75, 23);
            this.btnConnect_ArticulatedArm.TabIndex = 22;
            this.btnConnect_ArticulatedArm.Text = "Connect";
            this.btnConnect_ArticulatedArm.UseVisualStyleBackColor = true;
            this.btnConnect_ArticulatedArm.Click += new System.EventHandler(this.btnConnect_ArticulatedArm_Click);
            // 
            // btnJointParamsApply
            // 
            this.btnJointParamsApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJointParamsApply.Location = new System.Drawing.Point(6, 46);
            this.btnJointParamsApply.Name = "btnJointParamsApply";
            this.btnJointParamsApply.Size = new System.Drawing.Size(75, 43);
            this.btnJointParamsApply.TabIndex = 21;
            this.btnJointParamsApply.Text = "Apply Changes";
            this.btnJointParamsApply.UseVisualStyleBackColor = true;
            this.btnJointParamsApply.Click += new System.EventHandler(this.btnJointParamsApply_Click);
            // 
            // textBoxJointAngle
            // 
            this.textBoxJointAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxJointAngle.Location = new System.Drawing.Point(139, 59);
            this.textBoxJointAngle.Name = "textBoxJointAngle";
            this.textBoxJointAngle.Size = new System.Drawing.Size(57, 20);
            this.textBoxJointAngle.TabIndex = 20;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.ToolsMenu,
            this.HelpMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(731, 24);
            this.MainMenu.TabIndex = 16;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSettingsMenuItem,
            this.exitMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(35, 20);
            this.FileMenu.Text = "&File";
            // 
            // saveSettingsMenuItem
            // 
            this.saveSettingsMenuItem.Name = "saveSettingsMenuItem";
            this.saveSettingsMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveSettingsMenuItem.Text = "&Save Settings...";
            this.saveSettingsMenuItem.Click += new System.EventHandler(this.saveSettingsMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsMenuItem});
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.Size = new System.Drawing.Size(44, 20);
            this.ToolsMenu.Text = "&Tools";
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(122, 22);
            this.optionsMenuItem.Text = "&Options";
            this.optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(40, 20);
            this.HelpMenu.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aboutMenuItem.Text = "About ...";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // SonarGroupBox
            // 
            this.SonarGroupBox.Controls.Add(this.lblSonarS7);
            this.SonarGroupBox.Controls.Add(this.lblSonarS6);
            this.SonarGroupBox.Controls.Add(this.lblSonarS5);
            this.SonarGroupBox.Controls.Add(this.lblSonarS4);
            this.SonarGroupBox.Controls.Add(this.lblSonarS3);
            this.SonarGroupBox.Controls.Add(this.lblSonarS2);
            this.SonarGroupBox.Controls.Add(this.lblSonarS1);
            this.SonarGroupBox.Controls.Add(this.lblSonarS0);
            this.SonarGroupBox.Controls.Add(this.btnStartSonar);
            this.SonarGroupBox.Controls.Add(this.picSonar);
            this.SonarGroupBox.Controls.Add(this.btnDisconnectSonar);
            this.SonarGroupBox.Controls.Add(this.btnConnectSonar);
            this.SonarGroupBox.Controls.Add(this.lblSonarDelay);
            this.SonarGroupBox.Location = new System.Drawing.Point(394, 27);
            this.SonarGroupBox.Name = "SonarGroupBox";
            this.SonarGroupBox.Size = new System.Drawing.Size(325, 220);
            this.SonarGroupBox.TabIndex = 17;
            this.SonarGroupBox.TabStop = false;
            this.SonarGroupBox.Text = "SONAR";
            this.SonarGroupBox.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lblSonarS7
            // 
            this.lblSonarS7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonarS7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonarS7.Location = new System.Drawing.Point(238, 180);
            this.lblSonarS7.Name = "lblSonarS7";
            this.lblSonarS7.Size = new System.Drawing.Size(69, 18);
            this.lblSonarS7.TabIndex = 16;
            this.lblSonarS7.Text = "0";
            // 
            // lblSonarS6
            // 
            this.lblSonarS6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonarS6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonarS6.Location = new System.Drawing.Point(238, 161);
            this.lblSonarS6.Name = "lblSonarS6";
            this.lblSonarS6.Size = new System.Drawing.Size(69, 18);
            this.lblSonarS6.TabIndex = 15;
            this.lblSonarS6.Text = "0";
            // 
            // lblSonarS5
            // 
            this.lblSonarS5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonarS5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonarS5.Location = new System.Drawing.Point(238, 142);
            this.lblSonarS5.Name = "lblSonarS5";
            this.lblSonarS5.Size = new System.Drawing.Size(69, 18);
            this.lblSonarS5.TabIndex = 14;
            this.lblSonarS5.Text = "0";
            // 
            // lblSonarS4
            // 
            this.lblSonarS4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonarS4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonarS4.Location = new System.Drawing.Point(238, 123);
            this.lblSonarS4.Name = "lblSonarS4";
            this.lblSonarS4.Size = new System.Drawing.Size(69, 18);
            this.lblSonarS4.TabIndex = 13;
            this.lblSonarS4.Text = "0";
            // 
            // lblSonarS3
            // 
            this.lblSonarS3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonarS3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonarS3.Location = new System.Drawing.Point(238, 104);
            this.lblSonarS3.Name = "lblSonarS3";
            this.lblSonarS3.Size = new System.Drawing.Size(69, 18);
            this.lblSonarS3.TabIndex = 12;
            this.lblSonarS3.Text = "0";
            // 
            // lblSonarS2
            // 
            this.lblSonarS2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonarS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonarS2.Location = new System.Drawing.Point(238, 85);
            this.lblSonarS2.Name = "lblSonarS2";
            this.lblSonarS2.Size = new System.Drawing.Size(69, 18);
            this.lblSonarS2.TabIndex = 11;
            this.lblSonarS2.Text = "0";
            // 
            // lblSonarS1
            // 
            this.lblSonarS1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonarS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonarS1.Location = new System.Drawing.Point(238, 64);
            this.lblSonarS1.Name = "lblSonarS1";
            this.lblSonarS1.Size = new System.Drawing.Size(69, 18);
            this.lblSonarS1.TabIndex = 10;
            this.lblSonarS1.Text = "0";
            // 
            // lblSonarS0
            // 
            this.lblSonarS0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonarS0.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonarS0.Location = new System.Drawing.Point(238, 46);
            this.lblSonarS0.Name = "lblSonarS0";
            this.lblSonarS0.Size = new System.Drawing.Size(69, 18);
            this.lblSonarS0.TabIndex = 9;
            this.lblSonarS0.Text = "0";
            // 
            // btnStartSonar
            // 
            this.btnStartSonar.Enabled = false;
            this.btnStartSonar.Location = new System.Drawing.Point(6, 17);
            this.btnStartSonar.Name = "btnStartSonar";
            this.btnStartSonar.Size = new System.Drawing.Size(49, 23);
            this.btnStartSonar.TabIndex = 8;
            this.btnStartSonar.Text = "Start";
            this.btnStartSonar.UseVisualStyleBackColor = true;
            this.btnStartSonar.Click += new System.EventHandler(this.btnStartSonar_Click);
            // 
            // picSonar
            // 
            this.picSonar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSonar.Location = new System.Drawing.Point(6, 46);
            this.picSonar.Name = "picSonar";
            this.picSonar.Size = new System.Drawing.Size(226, 154);
            this.picSonar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSonar.TabIndex = 7;
            this.picSonar.TabStop = false;
            // 
            // btnDisconnectSonar
            // 
            this.btnDisconnectSonar.Enabled = false;
            this.btnDisconnectSonar.Location = new System.Drawing.Point(142, 17);
            this.btnDisconnectSonar.Name = "btnDisconnectSonar";
            this.btnDisconnectSonar.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnectSonar.TabIndex = 6;
            this.btnDisconnectSonar.Text = "Disconnect";
            this.btnDisconnectSonar.UseVisualStyleBackColor = true;
            this.btnDisconnectSonar.Click += new System.EventHandler(this.btnDisconnectSonar_Click);
            // 
            // btnConnectSonar
            // 
            this.btnConnectSonar.Enabled = false;
            this.btnConnectSonar.Location = new System.Drawing.Point(61, 17);
            this.btnConnectSonar.Name = "btnConnectSonar";
            this.btnConnectSonar.Size = new System.Drawing.Size(75, 23);
            this.btnConnectSonar.TabIndex = 5;
            this.btnConnectSonar.Text = "Connect";
            this.btnConnectSonar.UseVisualStyleBackColor = true;
            this.btnConnectSonar.Click += new System.EventHandler(this.btnConnectSonar_Click);
            // 
            // lblSonarDelay
            // 
            this.lblSonarDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonarDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonarDelay.Location = new System.Drawing.Point(223, 20);
            this.lblSonarDelay.Name = "lblSonarDelay";
            this.lblSonarDelay.Size = new System.Drawing.Size(93, 18);
            this.lblSonarDelay.TabIndex = 4;
            this.lblSonarDelay.Text = "0";
            // 
            // grBoxSonarMap
            // 
            this.grBoxSonarMap.Controls.Add(this.btnCamDisconnect);
            this.grBoxSonarMap.Controls.Add(this.btnCamConnect);
            this.grBoxSonarMap.Controls.Add(this.picCamImage);
            this.grBoxSonarMap.Location = new System.Drawing.Point(394, 250);
            this.grBoxSonarMap.Name = "grBoxSonarMap";
            this.grBoxSonarMap.Size = new System.Drawing.Size(325, 245);
            this.grBoxSonarMap.TabIndex = 18;
            this.grBoxSonarMap.TabStop = false;
            this.grBoxSonarMap.Text = "Onboard Camera";
            // 
            // btnCamDisconnect
            // 
            this.btnCamDisconnect.Enabled = false;
            this.btnCamDisconnect.Location = new System.Drawing.Point(87, 26);
            this.btnCamDisconnect.Name = "btnCamDisconnect";
            this.btnCamDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnCamDisconnect.TabIndex = 10;
            this.btnCamDisconnect.Text = "Disconnect";
            this.btnCamDisconnect.UseVisualStyleBackColor = true;
            this.btnCamDisconnect.Click += new System.EventHandler(this.btnCamDisconnect_Click);
            // 
            // btnCamConnect
            // 
            this.btnCamConnect.Enabled = false;
            this.btnCamConnect.Location = new System.Drawing.Point(6, 26);
            this.btnCamConnect.Name = "btnCamConnect";
            this.btnCamConnect.Size = new System.Drawing.Size(75, 23);
            this.btnCamConnect.TabIndex = 9;
            this.btnCamConnect.Text = "Connect";
            this.btnCamConnect.UseVisualStyleBackColor = true;
            this.btnCamConnect.Click += new System.EventHandler(this.btnCamConnect_Click);
            // 
            // picCamImage
            // 
            this.picCamImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCamImage.Location = new System.Drawing.Point(6, 67);
            this.picCamImage.Name = "picCamImage";
            this.picCamImage.Size = new System.Drawing.Size(226, 172);
            this.picCamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamImage.TabIndex = 8;
            this.picCamImage.TabStop = false;
            // 
            // groupBoxVision
            // 
            this.groupBoxVision.Controls.Add(this.picVisionObject);
            this.groupBoxVision.Controls.Add(this.label17);
            this.groupBoxVision.Controls.Add(this.picVisionFace);
            this.groupBoxVision.Controls.Add(this.picRightHand);
            this.groupBoxVision.Controls.Add(this.picLeftHand);
            this.groupBoxVision.Controls.Add(this.label16);
            this.groupBoxVision.Controls.Add(this.label15);
            this.groupBoxVision.Controls.Add(this.label14);
            this.groupBoxVision.Controls.Add(this.btnDisconnectVision);
            this.groupBoxVision.Controls.Add(this.btnConnectVision);
            this.groupBoxVision.Controls.Add(this.label13);
            this.groupBoxVision.Controls.Add(this.picMotion);
            this.groupBoxVision.Location = new System.Drawing.Point(394, 501);
            this.groupBoxVision.Name = "groupBoxVision";
            this.groupBoxVision.Size = new System.Drawing.Size(324, 322);
            this.groupBoxVision.TabIndex = 19;
            this.groupBoxVision.TabStop = false;
            this.groupBoxVision.Text = "Vision";
            // 
            // picVisionObject
            // 
            this.picVisionObject.Image = global::Cranium.Controls.Properties.Resources._object;
            this.picVisionObject.Location = new System.Drawing.Point(241, 226);
            this.picVisionObject.Name = "picVisionObject";
            this.picVisionObject.Size = new System.Drawing.Size(53, 56);
            this.picVisionObject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picVisionObject.TabIndex = 19;
            this.picVisionObject.TabStop = false;
            this.picVisionObject.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(243, 200);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "Object:";
            // 
            // picVisionFace
            // 
            this.picVisionFace.Image = global::Cranium.Controls.Properties.Resources.face;
            this.picVisionFace.Location = new System.Drawing.Point(26, 226);
            this.picVisionFace.Name = "picVisionFace";
            this.picVisionFace.Size = new System.Drawing.Size(55, 56);
            this.picVisionFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVisionFace.TabIndex = 13;
            this.picVisionFace.TabStop = false;
            this.picVisionFace.Visible = false;
            this.picVisionFace.Click += new System.EventHandler(this.picVisionFace_Click);
            // 
            // picRightHand
            // 
            this.picRightHand.Image = global::Cranium.Controls.Properties.Resources.right_hand;
            this.picRightHand.Location = new System.Drawing.Point(171, 226);
            this.picRightHand.Name = "picRightHand";
            this.picRightHand.Size = new System.Drawing.Size(53, 56);
            this.picRightHand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picRightHand.TabIndex = 17;
            this.picRightHand.TabStop = false;
            this.picRightHand.Visible = false;
            // 
            // picLeftHand
            // 
            this.picLeftHand.Image = global::Cranium.Controls.Properties.Resources.left_hand;
            this.picLeftHand.Location = new System.Drawing.Point(109, 226);
            this.picLeftHand.Name = "picLeftHand";
            this.picLeftHand.Size = new System.Drawing.Size(53, 56);
            this.picLeftHand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLeftHand.TabIndex = 16;
            this.picLeftHand.TabStop = false;
            this.picLeftHand.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(168, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Right Hand:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(105, 200);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Left Hand:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Face Detection:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // btnDisconnectVision
            // 
            this.btnDisconnectVision.Enabled = false;
            this.btnDisconnectVision.Location = new System.Drawing.Point(211, 66);
            this.btnDisconnectVision.Name = "btnDisconnectVision";
            this.btnDisconnectVision.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnectVision.TabIndex = 11;
            this.btnDisconnectVision.Text = "Disconnect";
            this.btnDisconnectVision.UseVisualStyleBackColor = true;
            // this.btnDisconnectVision.Click += new System.EventHandler(this.btnDisconnectVision_Click);
            // 
            // btnConnectVision
            // 
            this.btnConnectVision.Enabled = false;
            this.btnConnectVision.Location = new System.Drawing.Point(211, 37);
            this.btnConnectVision.Name = "btnConnectVision";
            this.btnConnectVision.Size = new System.Drawing.Size(75, 23);
            this.btnConnectVision.TabIndex = 10;
            this.btnConnectVision.Text = "Connect";
            this.btnConnectVision.UseVisualStyleBackColor = true;
            // this.btnConnectVision.Click += new System.EventHandler(this.btnConnectVision_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Motion";
            // 
            // picMotion
            // 
            this.picMotion.Location = new System.Drawing.Point(6, 37);
            this.picMotion.Name = "picMotion";
            this.picMotion.Size = new System.Drawing.Size(189, 150);
            this.picMotion.TabIndex = 0;
            this.picMotion.TabStop = false;
            // 
            // DriveControl
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(731, 778);
            this.Controls.Add(this.groupBoxVision);
            this.Controls.Add(this.grBoxSonarMap);
            this.Controls.Add(this.SonarGroupBox);
            this.Controls.Add(this.groupBoxArm);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBoxLRF);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainMenu);
            this.MinimumSize = new System.Drawing.Size(739, 768);
            this.Name = "DriveControl";
            this.Text = "CRANIUM Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DriveControl_FormClosed);
            this.Load += new System.EventHandler(this.DriveControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picJoystick)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxLRF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLRF)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBoxArm.ResumeLayout(false);
            this.groupBoxArm.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.SonarGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSonar)).EndInit();
            this.grBoxSonarMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamImage)).EndInit();
            this.groupBoxVision.ResumeLayout(false);
            this.groupBoxVision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVisionObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisionFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMotion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbJoystick;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblButtons;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listDirectory;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.MaskedTextBox txtPort;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.PictureBox picJoystick;
        private System.Windows.Forms.GroupBox groupBoxLRF;
        private System.Windows.Forms.Button btnConnectLRF;
        private System.Windows.Forms.Button btnStartLRF;
        private System.Windows.Forms.PictureBox picLRF;
        private System.Windows.Forms.CheckBox chkStop;
        private System.Windows.Forms.CheckBox chkDrive;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblMotor;
        private System.Windows.Forms.Label lblLag;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label lblNode;
        private System.Windows.Forms.LinkLabel linkDirectory;
        private System.Windows.Forms.GroupBox groupBoxArm;
        private System.Windows.Forms.TextBox textBoxJointAngle;
        private System.Windows.Forms.Button btnJointParamsApply;
        private System.Windows.Forms.Button btnConnect_ArticulatedArm;
        private System.Windows.Forms.ListBox listArticulatedArmJoints;
        private System.Windows.Forms.Label lblActiveJointValue;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox SonarGroupBox;
        private System.Windows.Forms.Label lblSonarDelay;
        private System.Windows.Forms.Button btnDisconnectSonar;
        private System.Windows.Forms.Button btnConnectSonar;
        private System.Windows.Forms.PictureBox picSonar;
        private System.Windows.Forms.Button btnStartSonar;
        private System.Windows.Forms.Label lblSonarS0;
        private System.Windows.Forms.Label lblSonarS1;
        private System.Windows.Forms.Label lblSonarS4;
        private System.Windows.Forms.Label lblSonarS3;
        private System.Windows.Forms.Label lblSonarS2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSonarS7;
        private System.Windows.Forms.Label lblSonarS6;
        private System.Windows.Forms.Label lblSonarS5;
        private System.Windows.Forms.GroupBox grBoxSonarMap;
        private System.Windows.Forms.PictureBox picCamImage;
        private System.Windows.Forms.Button btnCamDisconnect;
        private System.Windows.Forms.Button btnCamConnect;
        private System.Windows.Forms.GroupBox groupBoxVision;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox picMotion;
        private System.Windows.Forms.Button btnDisconnectVision;
        private System.Windows.Forms.Button btnConnectVision;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox picVisionFace;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox picRightHand;
        private System.Windows.Forms.PictureBox picLeftHand;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox picVisionObject;
    }
}