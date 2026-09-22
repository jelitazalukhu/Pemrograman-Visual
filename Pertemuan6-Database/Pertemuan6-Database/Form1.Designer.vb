<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        btnTampilkan = New Button()
        lblNama = New Label()
        lblNIM = New Label()
        lblJurusan = New Label()
        txtNama = New TextBox()
        txtNIM = New TextBox()
        txtJurusan = New TextBox()
        dgvMahasiswa = New DataGridView()
        btnTambah = New Button()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(248, 384)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(112, 34)
        btnTampilkan.TabIndex = 0
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(590, 42)
        lblNama.Name = "lblNama"
        lblNama.RightToLeft = RightToLeft.No
        lblNama.Size = New Size(68, 25)
        lblNama.TabIndex = 1
        lblNama.Text = "Nama :"
        ' 
        ' lblNIM
        ' 
        lblNIM.AutoSize = True
        lblNIM.Location = New Point(590, 102)
        lblNIM.Name = "lblNIM"
        lblNIM.Size = New Size(55, 25)
        lblNIM.TabIndex = 2
        lblNIM.Text = "NIM :"
        ' 
        ' lblJurusan
        ' 
        lblJurusan.AutoSize = True
        lblJurusan.Location = New Point(590, 164)
        lblJurusan.Name = "lblJurusan"
        lblJurusan.Size = New Size(80, 25)
        lblJurusan.TabIndex = 3
        lblJurusan.Text = "Jurusan :"
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(681, 39)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(198, 31)
        txtNama.TabIndex = 4
        ' 
        ' txtNIM
        ' 
        txtNIM.Location = New Point(681, 96)
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(198, 31)
        txtNIM.TabIndex = 5
        ' 
        ' txtJurusan
        ' 
        txtJurusan.Location = New Point(681, 164)
        txtJurusan.Name = "txtJurusan"
        txtJurusan.Size = New Size(198, 31)
        txtJurusan.TabIndex = 6
        ' 
        ' dgvMahasiswa
        ' 
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Location = New Point(46, 39)
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.RowHeadersWidth = 62
        dgvMahasiswa.Size = New Size(513, 310)
        dgvMahasiswa.TabIndex = 7
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(681, 234)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(198, 34)
        btnTambah.TabIndex = 8
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(931, 466)
        Controls.Add(btnTambah)
        Controls.Add(dgvMahasiswa)
        Controls.Add(txtJurusan)
        Controls.Add(txtNIM)
        Controls.Add(txtNama)
        Controls.Add(lblJurusan)
        Controls.Add(lblNIM)
        Controls.Add(lblNama)
        Controls.Add(btnTampilkan)
        Name = "Form1"
        Text = "Form1"
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblNama As Label
    Friend WithEvents lblNIM As Label
    Friend WithEvents lblJurusan As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents txtJurusan As TextBox
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents btnTambah As Button

End Class
