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
        lblNama = New Label()
        txtNama = New TextBox()
        lblNIM = New Label()
        txtNIM = New TextBox()
        lblKOM = New Label()
        txtKOM = New TextBox()
        btnTampilkan = New Button()
        btnHapus = New Button()
        btnKeluar = New Button()
        SuspendLayout()
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(223, 82)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(73, 25)
        lblNama.TabIndex = 0
        lblNama.Text = "Nama  :"
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(339, 82)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(150, 31)
        txtNama.TabIndex = 1
        ' 
        ' lblNIM
        ' 
        lblNIM.AutoSize = True
        lblNIM.Location = New Point(236, 149)
        lblNIM.Name = "lblNIM"
        lblNIM.Size = New Size(60, 25)
        lblNIM.TabIndex = 2
        lblNIM.Text = "NIM  :"
        ' 
        ' txtNIM
        ' 
        txtNIM.Location = New Point(339, 146)
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(150, 31)
        txtNIM.TabIndex = 3
        ' 
        ' lblKOM
        ' 
        lblKOM.AutoSize = True
        lblKOM.Location = New Point(231, 216)
        lblKOM.Name = "lblKOM"
        lblKOM.Size = New Size(65, 25)
        lblKOM.TabIndex = 4
        lblKOM.Text = "KOM  :"
        ' 
        ' txtKOM
        ' 
        txtKOM.Location = New Point(339, 213)
        txtKOM.Name = "txtKOM"
        txtKOM.Size = New Size(150, 31)
        txtKOM.TabIndex = 5
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(223, 265)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(112, 34)
        btnTampilkan.TabIndex = 6
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' btnHapus
        ' 
        btnHapus.Location = New Point(377, 265)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(112, 34)
        btnHapus.TabIndex = 7
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = True
        ' 
        ' btnKeluar
        ' 
        btnKeluar.Location = New Point(304, 314)
        btnKeluar.Name = "btnKeluar"
        btnKeluar.Size = New Size(112, 34)
        btnKeluar.TabIndex = 8
        btnKeluar.Text = "Keluar"
        btnKeluar.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnKeluar)
        Controls.Add(btnHapus)
        Controls.Add(btnTampilkan)
        Controls.Add(txtKOM)
        Controls.Add(lblKOM)
        Controls.Add(txtNIM)
        Controls.Add(lblNIM)
        Controls.Add(txtNama)
        Controls.Add(lblNama)
        Name = "Form1"
        Text = "Profile Mahasiswa"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNama As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents lblNIM As Label
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents lblKOM As Label
    Friend WithEvents txtKOM As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnKeluar As Button

    Private Sub txtNama_TextChanged(sender As Object, e As EventArgs) Handles txtNama.TextChanged

    End Sub

    Private Sub txtNIM_TextChanged(sender As Object, e As EventArgs) Handles txtNIM.TextChanged

    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        MessageBox.Show("Halo Selamat Datang !" & vbCrLf &
            "Nama : " & txtNama.Text & vbCrLf &
            "NIM  : " & txtNIM.Text & vbCrLf &
            "KOM  : " & txtKOM.Text
        )

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        txtNama.Clear()
        txtNIM.Clear()
        txtKOM.Clear()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class
