namespace UsingControls
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpFont = new System.Windows.Forms.GroupBox();
            this.txtSampleText = new System.Windows.Forms.TextBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.cboFont = new System.Windows.Forms.ComboBox();
            this.Label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDummy = new System.Windows.Forms.TrackBar();
            this.pbDummy = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMassage = new System.Windows.Forms.Button();
            this.btn_Modaless = new System.Windows.Forms.Button();
            this.btn_Modal = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvDummy = new System.Windows.Forms.ListView();
            this.tvDummy = new System.Windows.Forms.TreeView();
            this.btnChild = new System.Windows.Forms.Button();
            this.btnRoot = new System.Windows.Forms.Button();
            this.grpFont.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDummy)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFont
            // 
            this.grpFont.Controls.Add(this.txtSampleText);
            this.grpFont.Controls.Add(this.chkItalic);
            this.grpFont.Controls.Add(this.chkBold);
            this.grpFont.Controls.Add(this.cboFont);
            this.grpFont.Controls.Add(this.Label);
            this.grpFont.Location = new System.Drawing.Point(12, 12);
            this.grpFont.Name = "grpFont";
            this.grpFont.Size = new System.Drawing.Size(346, 136);
            this.grpFont.TabIndex = 0;
            this.grpFont.TabStop = false;
            this.grpFont.Text = "ComboBox, CheckBox, TextBox";
            // 
            // txtSampleText
            // 
            this.txtSampleText.Location = new System.Drawing.Point(29, 60);
            this.txtSampleText.Name = "txtSampleText";
            this.txtSampleText.Size = new System.Drawing.Size(274, 21);
            this.txtSampleText.TabIndex = 4;
            this.txtSampleText.Text = "Hello. C#";
            // 
            // chkItalic
            // 
            this.chkItalic.AutoSize = true;
            this.chkItalic.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkItalic.Location = new System.Drawing.Point(243, 36);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(60, 16);
            this.chkItalic.TabIndex = 3;
            this.chkItalic.Text = "이탤릭";
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.CheckedChanged += new System.EventHandler(this.chkItalic_CheckedChanged);
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Location = new System.Drawing.Point(189, 36);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(48, 16);
            this.chkBold.TabIndex = 2;
            this.chkBold.Text = "굵게";
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);
            // 
            // cboFont
            // 
            this.cboFont.FormattingEnabled = true;
            this.cboFont.Location = new System.Drawing.Point(62, 34);
            this.cboFont.Name = "cboFont";
            this.cboFont.Size = new System.Drawing.Size(121, 20);
            this.cboFont.TabIndex = 1;
            this.cboFont.SelectedIndexChanged += new System.EventHandler(this.cboFont_SelectedIndexChanged);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(27, 37);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(29, 12);
            this.Label.TabIndex = 0;
            this.Label.Text = "Font";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDummy);
            this.groupBox1.Controls.Add(this.pbDummy);
            this.groupBox1.Location = new System.Drawing.Point(12, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TrackBar & PrograssBar";
            // 
            // tbDummy
            // 
            this.tbDummy.Location = new System.Drawing.Point(6, 31);
            this.tbDummy.Maximum = 20;
            this.tbDummy.Name = "tbDummy";
            this.tbDummy.Size = new System.Drawing.Size(326, 45);
            this.tbDummy.TabIndex = 1;
            this.tbDummy.Scroll += new System.EventHandler(this.tbDummy_Scroll);
            // 
            // pbDummy
            // 
            this.pbDummy.Location = new System.Drawing.Point(6, 91);
            this.pbDummy.Maximum = 20;
            this.pbDummy.Name = "pbDummy";
            this.pbDummy.Size = new System.Drawing.Size(326, 32);
            this.pbDummy.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMassage);
            this.groupBox2.Controls.Add(this.btn_Modaless);
            this.groupBox2.Controls.Add(this.btn_Modal);
            this.groupBox2.Location = new System.Drawing.Point(12, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modal & Modaless";
            // 
            // btnMassage
            // 
            this.btnMassage.Location = new System.Drawing.Point(212, 25);
            this.btnMassage.Name = "btnMassage";
            this.btnMassage.Size = new System.Drawing.Size(119, 23);
            this.btnMassage.TabIndex = 2;
            this.btnMassage.Text = "MessageBox";
            this.btnMassage.UseVisualStyleBackColor = true;
            this.btnMassage.Click += new System.EventHandler(this.btnMassage_Click);
            // 
            // btn_Modaless
            // 
            this.btn_Modaless.Location = new System.Drawing.Point(110, 25);
            this.btn_Modaless.Name = "btn_Modaless";
            this.btn_Modaless.Size = new System.Drawing.Size(98, 23);
            this.btn_Modaless.TabIndex = 1;
            this.btn_Modaless.Text = "Modaless";
            this.btn_Modaless.UseVisualStyleBackColor = true;
            this.btn_Modaless.Click += new System.EventHandler(this.btn_Modaless_Click);
            // 
            // btn_Modal
            // 
            this.btn_Modal.Location = new System.Drawing.Point(6, 25);
            this.btn_Modal.Name = "btn_Modal";
            this.btn_Modal.Size = new System.Drawing.Size(98, 23);
            this.btn_Modal.TabIndex = 0;
            this.btn_Modal.Text = "Modal";
            this.btn_Modal.UseVisualStyleBackColor = true;
            this.btn_Modal.Click += new System.EventHandler(this.btn_Modal_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRoot);
            this.groupBox3.Controls.Add(this.btnChild);
            this.groupBox3.Controls.Add(this.tvDummy);
            this.groupBox3.Controls.Add(this.lvDummy);
            this.groupBox3.Location = new System.Drawing.Point(12, 388);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 161);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TreeView & ListView";
            // 
            // lvDummy
            // 
            this.lvDummy.Location = new System.Drawing.Point(172, 20);
            this.lvDummy.Name = "lvDummy";
            this.lvDummy.Size = new System.Drawing.Size(159, 100);
            this.lvDummy.TabIndex = 0;
            this.lvDummy.UseCompatibleStateImageBehavior = false;
            this.lvDummy.View = System.Windows.Forms.View.Details;
            // 
            // tvDummy
            // 
            this.tvDummy.Location = new System.Drawing.Point(6, 20);
            this.tvDummy.Name = "tvDummy";
            this.tvDummy.Size = new System.Drawing.Size(160, 100);
            this.tvDummy.TabIndex = 1;
            // 
            // btnChild
            // 
            this.btnChild.Location = new System.Drawing.Point(91, 132);
            this.btnChild.Name = "btnChild";
            this.btnChild.Size = new System.Drawing.Size(75, 23);
            this.btnChild.TabIndex = 3;
            this.btnChild.Text = "자식추가";
            this.btnChild.UseVisualStyleBackColor = true;
            this.btnChild.Click += new System.EventHandler(this.btnChild_Click);
            // 
            // btnRoot
            // 
            this.btnRoot.Location = new System.Drawing.Point(6, 132);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(75, 23);
            this.btnRoot.TabIndex = 4;
            this.btnRoot.Text = "루트추가";
            this.btnRoot.UseVisualStyleBackColor = true;
            this.btnRoot.Click += new System.EventHandler(this.btnRoot_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 563);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpFont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Control Test";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpFont.ResumeLayout(false);
            this.grpFont.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDummy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFont;
        private System.Windows.Forms.ComboBox cboFont;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.TextBox txtSampleText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar tbDummy;
        private System.Windows.Forms.ProgressBar pbDummy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMassage;
        private System.Windows.Forms.Button btn_Modaless;
        private System.Windows.Forms.Button btn_Modal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRoot;
        private System.Windows.Forms.Button btnChild;
        private System.Windows.Forms.TreeView tvDummy;
        private System.Windows.Forms.ListView lvDummy;
    }
}

