//-----------------------------------------------------------------------
//  This file is part of the Microsoft Robotics Studio Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  $File: DriveControl.Designer.cs $ $Revision: 6 $
//-----------------------------------------------------------------------

namespace Microsoft.Robotics.Services.Dashboard
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
            this.btnForward = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.lblLag = new System.Windows.Forms.Label();
            this.lblMotor = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
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
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
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
            // btnForward
            // 
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
            this.MainMenu.Size = new System.Drawing.Size(398, 24);
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
            // btnStop
            // 
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(112, 58);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(32, 32);
            this.btnStop.TabIndex = 22;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Image = ((System.Drawing.Image)(resources.GetObject("btnReverse.Image")));
            this.btnReverse.Location = new System.Drawing.Point(112, 96);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(32, 32);
            this.btnReverse.TabIndex = 23;
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(9, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 30);
            this.label11.TabIndex = 24;
            this.label11.Text = "Motion Control\r\n(See Options)";
            // 
            // DriveControl
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(398, 606);
            this.Controls.Add(this.groupBoxArm);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBoxLRF);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainMenu);
            this.MinimumSize = new System.Drawing.Size(406, 320);
            this.Name = "DriveControl";
            this.Text = "Dashboard";
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
    }
}