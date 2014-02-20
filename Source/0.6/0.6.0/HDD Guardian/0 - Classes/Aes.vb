'HDD Guardian is a GUI for smartcl utility, part of smartmontools
'
'home page is http://code.google.com/p/hddguardian/
'
'Copyright (C) 2010-2014 Samuele Parise
'
'This Source Code Form is subject to the terms of the Mozilla Public
'License, v. 2.0. If a copy of the MPL was not distributed with this
'file, You can obtain one at http://mozilla.org/MPL/2.0/.

Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Class Aes

    Public Function Encrypt(ByVal text As String, ByVal key As String, ByVal iv As String) As String
        Dim aes As New RijndaelManaged
        aes.BlockSize = 128
        aes.KeySize = 256
        aes.IV = Encoding.UTF8.GetBytes(iv)
        aes.Key = Encoding.UTF8.GetBytes(key)
        aes.Mode = CipherMode.CBC
        aes.Padding = PaddingMode.PKCS7

        Dim src As Byte() = Encoding.UTF8.GetBytes(text)

        Using enc As ICryptoTransform = aes.CreateEncryptor()
            Dim dest As Byte() = enc.TransformFinalBlock(src, 0, src.Length)
            Return Convert.ToBase64String(dest)
        End Using
    End Function

    Public Function Decrypt(ByVal text As String, ByVal key As String, ByVal iv As String) As String
        Dim aes As New RijndaelManaged
        aes.BlockSize = 128
        aes.KeySize = 256
        aes.IV = Encoding.UTF8.GetBytes(IV)
        aes.Key = Encoding.UTF8.GetBytes(Key)
        aes.Mode = CipherMode.CBC
        aes.Padding = PaddingMode.PKCS7

        Dim src As Byte() = System.Convert.FromBase64String(text)

        Using dec As ICryptoTransform = aes.CreateDecryptor()
            Dim dest As Byte() = dec.TransformFinalBlock(src, 0, src.Length)
            Return Encoding.UTF8.GetString(dest)
        End Using
    End Function

End Class
