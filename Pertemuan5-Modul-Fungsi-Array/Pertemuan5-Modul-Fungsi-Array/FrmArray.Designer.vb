<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmArray
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
        txtPanjang = New TextBox()
        txtLebar = New TextBox()
        lblPanjang = New Label()
        lblLebar = New Label()
        lstNilai = New ListBox()
        SuspendLayout()
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(123, 241)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(112, 34)
        btnTampilkan.TabIndex = 0
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' txtPanjang
        ' 
        txtPanjang.Location = New Point(111, 79)
        txtPanjang.Name = "txtPanjang"
        txtPanjang.Size = New Size(150, 31)
        txtPanjang.TabIndex = 1
        ' 
        ' txtLebar
        ' 
        txtLebar.Location = New Point(111, 185)
        txtLebar.Name = "txtLebar"
        txtLebar.Size = New Size(150, 31)
        txtLebar.TabIndex = 2
        ' 
        ' lblPanjang
        ' 
        lblPanjang.AutoSize = True
        lblPanjang.Location = New Point(111, 41)
        lblPanjang.Name = "lblPanjang"
        lblPanjang.Size = New Size(78, 25)
        lblPanjang.TabIndex = 3
        lblPanjang.Text = "Panjang:"
        ' 
        ' lblLebar
        ' 
        lblLebar.AutoSize = True
        lblLebar.Location = New Point(111, 141)
        lblLebar.Name = "lblLebar"
        lblLebar.Size = New Size(64, 25)
        lblLebar.TabIndex = 4
        lblLebar.Text = "Lebar :"
        ' 
        ' lstNilai
        ' 
        lstNilai.FormattingEnabled = True
        lstNilai.Location = New Point(100, 311)
        lstNilai.Name = "lstNilai"
        lstNilai.Size = New Size(180, 104)
        lstNilai.TabIndex = 5
        ' 
        ' FrmArray
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(385, 452)
        Controls.Add(lstNilai)
        Controls.Add(lblLebar)
        Controls.Add(lblPanjang)
        Controls.Add(txtLebar)
        Controls.Add(txtPanjang)
        Controls.Add(btnTampilkan)
        Name = "FrmArray"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTampilkan As Button
    Friend WithEvents txtPanjang As TextBox
    Friend WithEvents txtLebar As TextBox
    Friend WithEvents lblPanjang As Label
    Friend WithEvents lblLebar As Label
    Friend WithEvents lstNilai As ListBox

End Class
