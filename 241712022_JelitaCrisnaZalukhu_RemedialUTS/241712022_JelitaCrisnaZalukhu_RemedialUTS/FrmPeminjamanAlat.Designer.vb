<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPeminjamanAlat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lblJudulForm = New Label()
        lblAlat = New Label()
        lblJumlah = New Label()
        cboALat = New ComboBox()
        txtJumlah = New TextBox()
        btnPinjam = New Button()
        btnKembalikan = New Button()
        btnReset = New Button()
        dgvAlat = New DataGridView()
        lblTotal = New Label()
        lblTotalDipinjam = New Label()
        lblStatus = New Label()
        errInput = New ErrorProvider(components)
        bsAlat = New BindingSource(components)
        CType(dgvAlat, ComponentModel.ISupportInitialize).BeginInit()
        CType(errInput, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsAlat, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudulForm.Location = New Point(34, 31)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(429, 38)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Peminjaman Alat Laboratorium"
        ' 
        ' lblAlat
        ' 
        lblAlat.AutoSize = True
        lblAlat.Location = New Point(34, 99)
        lblAlat.Name = "lblAlat"
        lblAlat.Size = New Size(43, 25)
        lblAlat.TabIndex = 1
        lblAlat.Text = "Alat"
        ' 
        ' lblJumlah
        ' 
        lblJumlah.AutoSize = True
        lblJumlah.Location = New Point(34, 159)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(114, 25)
        lblJumlah.TabIndex = 2
        lblJumlah.Text = "Jumlah (Unit)"
        ' 
        ' cboALat
        ' 
        cboALat.DropDownStyle = ComboBoxStyle.DropDownList
        cboALat.FormattingEnabled = True
        cboALat.Location = New Point(164, 96)
        cboALat.Name = "cboALat"
        cboALat.Size = New Size(229, 33)
        cboALat.TabIndex = 3
        ' 
        ' txtJumlah
        ' 
        txtJumlah.Location = New Point(164, 159)
        txtJumlah.Name = "txtJumlah"
        txtJumlah.Size = New Size(229, 31)
        txtJumlah.TabIndex = 4
        ' 
        ' btnPinjam
        ' 
        btnPinjam.BackColor = SystemColors.Highlight
        btnPinjam.BackgroundImageLayout = ImageLayout.Center
        btnPinjam.FlatStyle = FlatStyle.Popup
        btnPinjam.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPinjam.ForeColor = SystemColors.ButtonHighlight
        btnPinjam.Location = New Point(423, 92)
        btnPinjam.Name = "btnPinjam"
        btnPinjam.Size = New Size(133, 39)
        btnPinjam.TabIndex = 5
        btnPinjam.Text = "Pinjam"
        btnPinjam.UseVisualStyleBackColor = False
        ' 
        ' btnKembalikan
        ' 
        btnKembalikan.BackColor = Color.ForestGreen
        btnKembalikan.FlatStyle = FlatStyle.Popup
        btnKembalikan.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnKembalikan.ForeColor = SystemColors.ButtonHighlight
        btnKembalikan.Location = New Point(583, 92)
        btnKembalikan.Name = "btnKembalikan"
        btnKembalikan.Size = New Size(133, 39)
        btnKembalikan.TabIndex = 6
        btnKembalikan.Text = "Kembalikan"
        btnKembalikan.UseVisualStyleBackColor = False
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.Gray
        btnReset.FlatStyle = FlatStyle.Popup
        btnReset.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnReset.ForeColor = SystemColors.ButtonHighlight
        btnReset.Location = New Point(752, 92)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(133, 39)
        btnReset.TabIndex = 7
        btnReset.Text = "Reset Data"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' dgvAlat
        ' 
        dgvAlat.BackgroundColor = SystemColors.ButtonFace
        dgvAlat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAlat.Location = New Point(34, 225)
        dgvAlat.Name = "dgvAlat"
        dgvAlat.RowHeadersWidth = 62
        dgvAlat.Size = New Size(851, 225)
        dgvAlat.TabIndex = 8
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotal.Location = New Point(34, 480)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(180, 28)
        lblTotal.TabIndex = 9
        lblTotal.Text = "Total Unit Dipinjam"
        ' 
        ' lblTotalDipinjam
        ' 
        lblTotalDipinjam.AutoSize = True
        lblTotalDipinjam.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalDipinjam.Location = New Point(815, 480)
        lblTotalDipinjam.Name = "lblTotalDipinjam"
        lblTotalDipinjam.Size = New Size(70, 28)
        lblTotalDipinjam.TabIndex = 10
        lblTotalDipinjam.Text = "0 Unit"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblStatus.Location = New Point(34, 529)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(392, 21)
        lblStatus.TabIndex = 11
        lblStatus.Text = "Stok tersedia + dipinjam selalu sama dengan stok awal."
        ' 
        ' errInput
        ' 
        errInput.ContainerControl = Me
        ' 
        ' FrmPeminjamanAlat
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(921, 578)
        Controls.Add(lblStatus)
        Controls.Add(lblTotalDipinjam)
        Controls.Add(lblTotal)
        Controls.Add(dgvAlat)
        Controls.Add(btnReset)
        Controls.Add(btnKembalikan)
        Controls.Add(btnPinjam)
        Controls.Add(txtJumlah)
        Controls.Add(cboALat)
        Controls.Add(lblJumlah)
        Controls.Add(lblAlat)
        Controls.Add(lblJudulForm)
        Name = "FrmPeminjamanAlat"
        StartPosition = FormStartPosition.CenterScreen
        Text = " Peminjaman Alat Laboratorium"
        CType(dgvAlat, ComponentModel.ISupportInitialize).EndInit()
        CType(errInput, ComponentModel.ISupportInitialize).EndInit()
        CType(bsAlat, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblAlat As Label
    Friend WithEvents lblJumlah As Label
    Friend WithEvents cboALat As ComboBox
    Friend WithEvents txtJumlah As TextBox
    Friend WithEvents btnPinjam As Button
    Friend WithEvents btnKembalikan As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents dgvAlat As DataGridView
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTotalDipinjam As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents errInput As ErrorProvider
    Friend WithEvents bsAlat As BindingSource

End Class
