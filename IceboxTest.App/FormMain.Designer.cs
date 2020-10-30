using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IceboxTest.App
{
     partial class FormMain : Form
     {

          public FormMain()
          {
               InitializeComponent();
          }

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
               if (disposing && ( components != null ))
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
               this.components = new System.ComponentModel.Container();
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
               this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
               this.toolStrip1 = new System.Windows.Forms.ToolStrip();
               this.btnStart = new System.Windows.Forms.ToolStripButton();
               this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
               this.btnPause = new System.Windows.Forms.ToolStripButton();
               this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
               this.btnStop = new System.Windows.Forms.ToolStripButton();
               this.toolStrip1.SuspendLayout();
               this.SuspendLayout();
               // 
               // AnimationTimer
               // 
               this.AnimationTimer.Interval = 16;
               this.AnimationTimer.Tick += new System.EventHandler(this.OnAnimationTick);
               // 
               // toolStrip1
               // 
               this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
               this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.toolStripSeparator1,
            this.btnPause,
            this.toolStripSeparator2,
            this.btnStop});
               this.toolStrip1.Location = new System.Drawing.Point(0, 0);
               this.toolStrip1.Name = "toolStrip1";
               this.toolStrip1.Size = new System.Drawing.Size(800, 31);
               this.toolStrip1.TabIndex = 0;
               this.toolStrip1.Text = "toolStrip1";
               // 
               // btnStart
               // 
               this.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.btnStart.Image = ( (System.Drawing.Image)( resources.GetObject("btnStart.Image") ) );
               this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.btnStart.Name = "btnStart";
               this.btnStart.Size = new System.Drawing.Size(28, 28);
               this.btnStart.Text = "Start";
               this.btnStart.ToolTipText = "Start Button";
               this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
               // 
               // toolStripSeparator1
               // 
               this.toolStripSeparator1.Name = "toolStripSeparator1";
               this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
               // 
               // btnPause
               // 
               this.btnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.btnPause.Image = ( (System.Drawing.Image)( resources.GetObject("btnPause.Image") ) );
               this.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.btnPause.Name = "btnPause";
               this.btnPause.Size = new System.Drawing.Size(28, 28);
               this.btnPause.Text = "Pause button";
               this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
               // 
               // toolStripSeparator2
               // 
               this.toolStripSeparator2.Name = "toolStripSeparator2";
               this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
               // 
               // btnStop
               // 
               this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
               this.btnStop.Image = ( (System.Drawing.Image)( resources.GetObject("btnStop.Image") ) );
               this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
               this.btnStop.Name = "btnStop";
               this.btnStop.Size = new System.Drawing.Size(28, 28);
               this.btnStop.Text = "Stop";
               this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
               // 
               // FormMain
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(800, 450);
               this.Controls.Add(this.toolStrip1);
               this.Name = "FormMain";
               this.Text = "FormMain";
               this.toolStrip1.ResumeLayout(false);
               this.toolStrip1.PerformLayout();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Timer AnimationTimer;
          private ToolStrip toolStrip1;
          private ToolStripButton btnStart;
          private ToolStripSeparator toolStripSeparator1;
          private ToolStripButton btnPause;
          private ToolStripSeparator toolStripSeparator2;
          private ToolStripButton btnStop;
     }
}