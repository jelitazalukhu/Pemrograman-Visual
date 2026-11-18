<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInventaris
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
        lblStok = New Label()
        lblTahunTerbit = New Label()
        lblKategori = New Label()
        lblPenulis = New Label()
        lblJudul = New Label()
        lblKodeBuku = New Label()
        lblFilter = New Label()
        lblCari = New Label()
        txtKodeBuku = New TextBox()
        txtJudul = New TextBox()
        txtPenulis = New TextBox()
        txtTahun = New TextBox()
        txtStok = New TextBox()
        txtCari = New TextBox()
        cboKategori = New ComboBox()
        cboFilterKategori = New ComboBox()
        btnTambah = New Button()
        btnBersihkan = New Button()
        dgvBuku = New DataGridView()
        cboUrut = New ComboBox()
        lblUrut = New Label()
        chkStokHabis = New CheckBox()
        lblJumlah = New Label()
        lblTotalStok = New Label()
        errBuku = New ErrorProvider(components)
        bsBuku = New BindingSource(components)
        CType(dgvBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(errBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudulForm.Location = New Point(12, 9)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(354, 32)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Inventaris Buku Perpustakaan"
        ' 
        ' lblStok
        ' 
        lblStok.AutoSize = True
        lblStok.Location = New Point(35, 552)
        lblStok.Name = "lblStok"
        lblStok.Size = New Size(47, 25)
        lblStok.TabIndex = 1
        lblStok.Text = "Stok"
        ' 
        ' lblTahunTerbit
        ' 
        lblTahunTerbit.AutoSize = True
        lblTahunTerbit.Location = New Point(32, 457)
        lblTahunTerbit.Name = "lblTahunTerbit"
        lblTahunTerbit.Size = New Size(106, 25)
        lblTahunTerbit.TabIndex = 2
        lblTahunTerbit.Text = "Tahun Terbit"
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Location = New Point(35, 353)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(78, 25)
        lblKategori.TabIndex = 3
        lblKategori.Text = "Kategori"
        ' 
        ' lblPenulis
        ' 
        lblPenulis.AutoSize = True
        lblPenulis.Location = New Point(32, 259)
        lblPenulis.Name = "lblPenulis"
        lblPenulis.Size = New Size(66, 25)
        lblPenulis.TabIndex = 4
        lblPenulis.Text = "Penulis"
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Location = New Point(32, 170)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(97, 25)
        lblJudul.TabIndex = 5
        lblJudul.Text = "Judul Buku"
        ' 
        ' lblKodeBuku
        ' 
        lblKodeBuku.AutoSize = True
        lblKodeBuku.Location = New Point(32, 74)
        lblKodeBuku.Name = "lblKodeBuku"
        lblKodeBuku.Size = New Size(97, 25)
        lblKodeBuku.TabIndex = 6
        lblKodeBuku.Text = "Kode Buku"
        ' 
        ' lblFilter
        ' 
        lblFilter.AutoSize = True
        lblFilter.Location = New Point(460, 170)
        lblFilter.Name = "lblFilter"
        lblFilter.Size = New Size(121, 25)
        lblFilter.TabIndex = 7
        lblFilter.Text = "Filter Kategori"
        ' 
        ' lblCari
        ' 
        lblCari.AutoSize = True
        lblCari.Location = New Point(460, 74)
        lblCari.Name = "lblCari"
        lblCari.Size = New Size(149, 25)
        lblCari.TabIndex = 8
        lblCari.Text = "Cari judul/penulis"
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.Location = New Point(35, 113)
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(377, 31)
        txtKodeBuku.TabIndex = 9
        ' 
        ' txtJudul
        ' 
        txtJudul.Location = New Point(32, 211)
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(380, 31)
        txtJudul.TabIndex = 10
        ' 
        ' txtPenulis
        ' 
        txtPenulis.Location = New Point(32, 299)
        txtPenulis.Name = "txtPenulis"
        txtPenulis.Size = New Size(380, 31)
        txtPenulis.TabIndex = 11
        ' 
        ' txtTahun
        ' 
        txtTahun.Location = New Point(32, 499)
        txtTahun.Name = "txtTahun"
        txtTahun.Size = New Size(380, 31)
        txtTahun.TabIndex = 12
        ' 
        ' txtStok
        ' 
        txtStok.Location = New Point(35, 591)
        txtStok.Name = "txtStok"
        txtStok.Size = New Size(377, 31)
        txtStok.TabIndex = 13
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(460, 113)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(798, 31)
        txtCari.TabIndex = 14
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.FormattingEnabled = True
        cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboKategori.Location = New Point(32, 393)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(380, 33)
        cboKategori.TabIndex = 16
        ' 
        ' cboFilterKategori
        ' 
        cboFilterKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterKategori.FormattingEnabled = True
        cboFilterKategori.Items.AddRange(New Object() {"Semua", "Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboFilterKategori.Location = New Point(460, 209)
        cboFilterKategori.Name = "cboFilterKategori"
        cboFilterKategori.Size = New Size(251, 33)
        cboFilterKategori.TabIndex = 17
        ' 
        ' btnTambah
        ' 
        btnTambah.BackColor = Color.ForestGreen
        btnTambah.BackgroundImageLayout = ImageLayout.None
        btnTambah.FlatStyle = FlatStyle.Flat
        btnTambah.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnTambah.ForeColor = SystemColors.ControlLightLight
        btnTambah.Location = New Point(35, 651)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(377, 49)
        btnTambah.TabIndex = 18
        btnTambah.Text = "Tambah Buku"
        btnTambah.UseVisualStyleBackColor = False
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.BackgroundImageLayout = ImageLayout.None
        btnBersihkan.CausesValidation = False
        btnBersihkan.FlatStyle = FlatStyle.Flat
        btnBersihkan.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBersihkan.Location = New Point(35, 723)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(377, 49)
        btnBersihkan.TabIndex = 19
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = True
        ' 
        ' dgvBuku
        ' 
        dgvBuku.AllowUserToAddRows = False
        dgvBuku.BackgroundColor = SystemColors.ButtonFace
        dgvBuku.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBuku.Location = New Point(460, 275)
        dgvBuku.MultiSelect = False
        dgvBuku.Name = "dgvBuku"
        dgvBuku.ReadOnly = True
        dgvBuku.RowHeadersWidth = 62
        dgvBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBuku.Size = New Size(798, 503)
        dgvBuku.TabIndex = 20
        ' 
        ' cboUrut
        ' 
        cboUrut.DropDownStyle = ComboBoxStyle.DropDownList
        cboUrut.FormattingEnabled = True
        cboUrut.Items.AddRange(New Object() {"Urutan awal", "Judul A-Z", "Tahun terbaru", "Stok terbanyak"})
        cboUrut.Location = New Point(932, 211)
        cboUrut.Name = "cboUrut"
        cboUrut.Size = New Size(326, 33)
        cboUrut.TabIndex = 21
        ' 
        ' lblUrut
        ' 
        lblUrut.AutoSize = True
        lblUrut.Location = New Point(932, 170)
        lblUrut.Name = "lblUrut"
        lblUrut.Size = New Size(118, 25)
        lblUrut.TabIndex = 22
        lblUrut.Text = "Urutkan Buku"
        ' 
        ' chkStokHabis
        ' 
        chkStokHabis.AutoSize = True
        chkStokHabis.Location = New Point(737, 213)
        chkStokHabis.Name = "chkStokHabis"
        chkStokHabis.Size = New Size(178, 29)
        chkStokHabis.TabIndex = 23
        chkStokHabis.Text = "Hanya Stok Habis"
        chkStokHabis.UseVisualStyleBackColor = True
        ' 
        ' lblJumlah
        ' 
        lblJumlah.AutoSize = True
        lblJumlah.Location = New Point(460, 797)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(230, 25)
        lblJumlah.TabIndex = 24
        lblJumlah.Text = "Menampilkan X dari Y buku"
        ' 
        ' lblTotalStok
        ' 
        lblTotalStok.AutoSize = True
        lblTotalStok.Location = New Point(750, 797)
        lblTotalStok.Name = "lblTotalStok"
        lblTotalStok.Size = New Size(206, 25)
        lblTotalStok.TabIndex = 25
        lblTotalStok.Text = "Total stok yang tampil: 0"
        ' 
        ' errBuku
        ' 
        errBuku.ContainerControl = Me
        ' 
        ' FrmInventaris
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1310, 847)
        Controls.Add(lblTotalStok)
        Controls.Add(lblJumlah)
        Controls.Add(chkStokHabis)
        Controls.Add(lblUrut)
        Controls.Add(cboUrut)
        Controls.Add(dgvBuku)
        Controls.Add(btnBersihkan)
        Controls.Add(btnTambah)
        Controls.Add(cboFilterKategori)
        Controls.Add(cboKategori)
        Controls.Add(txtCari)
        Controls.Add(txtStok)
        Controls.Add(txtTahun)
        Controls.Add(txtPenulis)
        Controls.Add(txtJudul)
        Controls.Add(txtKodeBuku)
        Controls.Add(lblCari)
        Controls.Add(lblFilter)
        Controls.Add(lblKodeBuku)
        Controls.Add(lblJudul)
        Controls.Add(lblPenulis)
        Controls.Add(lblKategori)
        Controls.Add(lblTahunTerbit)
        Controls.Add(lblStok)
        Controls.Add(lblJudulForm)
        Name = "FrmInventaris"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inventaris Buku Perpustakaan"
        CType(dgvBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(errBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblStok As Label
    Friend WithEvents lblTahunTerbit As Label
    Friend WithEvents lblKategori As Label
    Friend WithEvents lblPenulis As Label
    Friend WithEvents lblJudul As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents lblFilter As Label
    Friend WithEvents lblCari As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents txtPenulis As TextBox
    Friend WithEvents txtTahun As TextBox
    Friend WithEvents txtStok As TextBox
    Friend WithEvents txtCari As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents cboFilterKategori As ComboBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents dgvBuku As DataGridView
    Friend WithEvents cboUrut As ComboBox
    Friend WithEvents lblUrut As Label
    Friend WithEvents chkStokHabis As CheckBox
    Friend WithEvents lblJumlah As Label
    Friend WithEvents lblTotalStok As Label
    Friend WithEvents errBuku As ErrorProvider
    Friend WithEvents bsBuku As BindingSource

End Class
