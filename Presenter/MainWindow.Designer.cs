namespace Presenter
{
   partial class MainWindow
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
         this.panel = new System.Windows.Forms.Panel();
         this.btnLoadFile = new System.Windows.Forms.Button();
         this.openFile = new System.Windows.Forms.OpenFileDialog();
         this.btnRefresh = new System.Windows.Forms.Button();
         this.cbLoadedGraphs = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.btnDrawCriticalPath = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // panel
         // 
         this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel.Location = new System.Drawing.Point(252, 12);
         this.panel.Name = "panel";
         this.panel.Size = new System.Drawing.Size(536, 426);
         this.panel.TabIndex = 0;
         // 
         // btnLoadFile
         // 
         this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.btnLoadFile.Location = new System.Drawing.Point(12, 308);
         this.btnLoadFile.Name = "btnLoadFile";
         this.btnLoadFile.Size = new System.Drawing.Size(234, 45);
         this.btnLoadFile.TabIndex = 1;
         this.btnLoadFile.Text = "Załaduj graf";
         this.btnLoadFile.UseVisualStyleBackColor = true;
         this.btnLoadFile.Click += new System.EventHandler(this.LoadFileButtonClicked);
         // 
         // openFile
         // 
         this.openFile.FileName = "openFile";
         // 
         // btnRefresh
         // 
         this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.btnRefresh.Location = new System.Drawing.Point(12, 63);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(234, 40);
         this.btnRefresh.TabIndex = 2;
         this.btnRefresh.Text = "Odśwież graf";
         this.btnRefresh.UseVisualStyleBackColor = true;
         this.btnRefresh.Click += new System.EventHandler(this.RefreshButtonClicked);
         // 
         // cbLoadedGraphs
         // 
         this.cbLoadedGraphs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cbLoadedGraphs.FormattingEnabled = true;
         this.cbLoadedGraphs.Location = new System.Drawing.Point(12, 390);
         this.cbLoadedGraphs.Name = "cbLoadedGraphs";
         this.cbLoadedGraphs.Size = new System.Drawing.Size(234, 21);
         this.cbLoadedGraphs.TabIndex = 3;
         this.cbLoadedGraphs.SelectedIndexChanged += new System.EventHandler(this.LoadedGraphsSelectedIndexChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 365);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(97, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "Załadowane grafy:";
         // 
         // btnDrawCriticalPath
         // 
         this.btnDrawCriticalPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.btnDrawCriticalPath.Location = new System.Drawing.Point(12, 12);
         this.btnDrawCriticalPath.Name = "btnDrawCriticalPath";
         this.btnDrawCriticalPath.Size = new System.Drawing.Size(234, 40);
         this.btnDrawCriticalPath.TabIndex = 2;
         this.btnDrawCriticalPath.Text = "Wyznacz ścieżkę krytyczną";
         this.btnDrawCriticalPath.UseVisualStyleBackColor = true;
         this.btnDrawCriticalPath.Click += new System.EventHandler(this.RefreshButtonClicked);
         // 
         // MainWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cbLoadedGraphs);
         this.Controls.Add(this.btnDrawCriticalPath);
         this.Controls.Add(this.btnRefresh);
         this.Controls.Add(this.btnLoadFile);
         this.Controls.Add(this.panel);
         this.Name = "MainWindow";
         this.Text = "Projektowanie i harmonogramowanie produkcji";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel;
      private System.Windows.Forms.Button btnLoadFile;
      private System.Windows.Forms.OpenFileDialog openFile;
      private System.Windows.Forms.Button btnRefresh;
      private System.Windows.Forms.ComboBox cbLoadedGraphs;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button btnDrawCriticalPath;
   }
}

