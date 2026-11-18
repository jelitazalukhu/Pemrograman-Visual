Option Strict On

Module ModValidasi

    ' Memeriksa apakah teks panjangnya tepat "panjang" dan seluruhnya angka 0-9.
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function

    ' Memeriksa format kode buku: "BK" diikuti 4 digit, contoh BK0012.
    ' Huruf kecil tetap diterima.
    Public Function KodeBukuValid(kode As String) As Boolean
        Dim k As String = kode.Trim().ToUpper()

        ' Panjang harus 6
        If k.Length <> 6 Then Return False
        If Not k.StartsWith("BK") Then Return False

        Return SemuaDigit(k.Substring(2), 4)
    End Function

    ' Mengamankan teks pengguna sebelum dipakai di ekspresi Filter (LIKE):
    ' tanda kutip tunggal digandakan, dan karakter khusus LIKE (* % [ ])
    ' dibungkus kurung siku agar dianggap huruf biasa.

    Public Function AmankanFilter(teks As String) As String
        Dim hasil As String = ""
        For Each karakter As Char In teks
            Select Case karakter
                Case "'"c
                    hasil &= "''"
                Case "*"c, "%"c, "["c, "]"c
                    hasil &= "[" & karakter & "]"
                Case Else
                    hasil &= karakter
            End Select
        Next
        Return hasil
    End Function

End Module