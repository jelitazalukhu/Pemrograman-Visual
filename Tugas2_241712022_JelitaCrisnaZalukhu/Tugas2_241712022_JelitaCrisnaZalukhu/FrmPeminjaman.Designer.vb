<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPeminjaman
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
        lblKode = New Label()
        lblJudul = New Label()
        lblKategori = New Label()
        lblNama = New Label()
        lblLamaPinjam = New Label()
        txtLamaPinjam = New TextBox()
        txtNamaPeminjam = New TextBox()
        txtJudul = New TextBox()
        txtKodeBuku = New TextBox()
        cboKategori = New ComboBox()
        btnPinjam = New Button()
        btnBersihkan = New Button()
        btnEkspor = New Button()
        lstPeminjaman = New ListBox()
        errPinjam = New ErrorProvider(components)
        lblStatus = New Label()
        CType(errPinjam, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudulForm.Location = New Point(30, 29)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(256, 38)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Peminjaman Buku"
        ' 
        ' lblKode
        ' 
        lblKode.AutoSize = True
        lblKode.Location = New Point(30, 94)
        lblKode.Name = "lblKode"
        lblKode.Size = New Size(101, 25)
        lblKode.TabIndex = 1
        lblKode.Text = "Kode Buku:"
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Location = New Point(30, 191)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(101, 25)
        lblJudul.TabIndex = 2
        lblJudul.Text = "Judul Buku:"
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Location = New Point(30, 280)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(82, 25)
        lblKategori.TabIndex = 3
        lblKategori.Text = "Kategori:"
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(30, 365)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(145, 25)
        lblNama.TabIndex = 4
        lblNama.Text = "Nama Peminjam:"
        ' 
        ' lblLamaPinjam
        ' 
        lblLamaPinjam.AutoSize = True
        lblLamaPinjam.Location = New Point(30, 457)
        lblLamaPinjam.Name = "lblLamaPinjam"
        lblLamaPinjam.Size = New Size(156, 25)
        lblLamaPinjam.TabIndex = 5
        lblLamaPinjam.Text = "Lama Pinjam (hari)"
        ' 
        ' txtLamaPinjam
        ' 
        txtLamaPinjam.Location = New Point(30, 498)
        txtLamaPinjam.Name = "txtLamaPinjam"
        txtLamaPinjam.Size = New Size(406, 31)
        txtLamaPinjam.TabIndex = 6
        ' 
        ' txtNamaPeminjam
        ' 
        txtNamaPeminjam.Location = New Point(30, 405)
        txtNamaPeminjam.Name = "txtNamaPeminjam"
        txtNamaPeminjam.Size = New Size(406, 31)
        txtNamaPeminjam.TabIndex = 7
        ' 
        ' txtJudul
        ' 
        txtJudul.Location = New Point(30, 229)
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(406, 31)
        txtJudul.TabIndex = 8
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.Location = New Point(30, 131)
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(406, 31)
        txtKodeBuku.TabIndex = 9
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.FormattingEnabled = True
        cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboKategori.Location = New Point(30, 308)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(406, 33)
        cboKategori.TabIndex = 10
        ' 
        ' btnPinjam
        ' 
        btnPinjam.BackColor = Color.Green
        btnPinjam.BackgroundImageLayout = ImageLayout.None
        btnPinjam.FlatStyle = FlatStyle.Flat
        btnPinjam.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPinjam.ForeColor = SystemColors.ButtonFace
        btnPinjam.Location = New Point(30, 552)
        btnPinjam.Name = "btnPinjam"
        btnPinjam.Size = New Size(180, 45)
        btnPinjam.TabIndex = 11
        btnPinjam.Text = "Pinjam"
        btnPinjam.UseVisualStyleBackColor = False
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.BackColor = Color.MistyRose
        btnBersihkan.BackgroundImageLayout = ImageLayout.None
        btnBersihkan.CausesValidation = False
        btnBersihkan.FlatStyle = FlatStyle.Flat
        btnBersihkan.Location = New Point(252, 552)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(184, 45)
        btnBersihkan.TabIndex = 12
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = False
        ' 
        ' btnEkspor
        ' 
        btnEkspor.BackColor = Color.SteelBlue
        btnEkspor.BackgroundImageLayout = ImageLayout.None
        btnEkspor.FlatStyle = FlatStyle.Flat
        btnEkspor.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEkspor.ForeColor = SystemColors.ButtonFace
        btnEkspor.Location = New Point(807, 552)
        btnEkspor.Name = "btnEkspor"
        btnEkspor.Size = New Size(184, 45)
        btnEkspor.TabIndex = 13
        btnEkspor.Text = "Ekspor CSV"
        btnEkspor.UseVisualStyleBackColor = False
        ' 
        ' lstPeminjaman
        ' 
        lstPeminjaman.FormattingEnabled = True
        lstPeminjaman.Location = New Point(464, 75)
        lstPeminjaman.Name = "lstPeminjaman"
        lstPeminjaman.Size = New Size(527, 454)
        lstPeminjaman.TabIndex = 14
        ' 
        ' errPinjam
        ' 
        errPinjam.ContainerControl = Me
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(30, 630)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(192, 25)
        lblStatus.TabIndex = 15
        lblStatus.Text = "Jumlah peminjaman: N"
        ' 
        ' FrmPeminjaman
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImageLayout = ImageLayout.Center
        ClientSize = New Size(1030, 701)
        Controls.Add(lblStatus)
        Controls.Add(lstPeminjaman)
        Controls.Add(btnEkspor)
        Controls.Add(btnBersihkan)
        Controls.Add(btnPinjam)
        Controls.Add(cboKategori)
        Controls.Add(txtKodeBuku)
        Controls.Add(txtJudul)
        Controls.Add(txtNamaPeminjam)
        Controls.Add(txtLamaPinjam)
        Controls.Add(lblLamaPinjam)
        Controls.Add(lblNama)
        Controls.Add(lblKategori)
        Controls.Add(lblJudul)
        Controls.Add(lblKode)
        Controls.Add(lblJudulForm)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "FrmPeminjaman"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form Peminjaman"
        CType(errPinjam, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKode As Label
    Friend WithEvents lblJudul As Label
    Friend WithEvents lblKategori As Label
    Friend WithEvents lblNama As Label
    Friend WithEvents lblLamaPinjam As Label
    Friend WithEvents txtLamaPinjam As TextBox
    Friend WithEvents txtNamaPeminjam As TextBox
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents btnPinjam As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents btnEkspor As Button
    Friend WithEvents lstPeminjaman As ListBox
    Friend WithEvents errPinjam As ErrorProvider
    Friend WithEvents lblStatus As Label

End Class
