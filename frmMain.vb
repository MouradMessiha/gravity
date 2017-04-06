Public Class frmMain

   Private mobjFormBitmap As Bitmap
   Private mobjBitmapGraphics As Graphics
   Private mintFormWidth As Integer
   Private mintFormHeight As Integer
   Private mintCurrentX As Int16 = 0
   Private mintCurrentY As Int16 = 0
   Private mintPrevX As Int16
   Private mintPrevY As Int16
   Private mblnExit As Boolean = False
   Private mintXSpeed As Int16 = 0

   Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

      Static blnDoneOnce As Boolean = False

      If Not blnDoneOnce Then
         blnDoneOnce = True
         mintFormWidth = Me.Width
         mintFormHeight = Me.Height
         mobjFormBitmap = New Bitmap(mintFormWidth, mintFormHeight, Me.CreateGraphics())
         mobjBitmapGraphics = Graphics.FromImage(mobjFormBitmap)
         mobjBitmapGraphics.FillRectangle(Brushes.White, 0, 0, mintFormWidth, mintFormHeight)
      End If

   End Sub

   Private Sub frmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

      e.Graphics.DrawImage(mobjFormBitmap, 0, 0)

   End Sub

   Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)

      ' to remove the flickering

   End Sub

   Private Sub frmMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

      If e.Button = Windows.Forms.MouseButtons.Left Then
         mobjBitmapGraphics.FillEllipse(Brushes.Black, e.X - 2, e.Y - 2, 7, 7)
         Me.Invalidate()
      End If

   End Sub

   Private Sub frmMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

      If e.Button = Windows.Forms.MouseButtons.Right Then

         mintCurrentX = e.X
         mintCurrentY = e.Y

         mintPrevX = mintCurrentX
         mintPrevY = mintCurrentY

         mobjBitmapGraphics.FillEllipse(Brushes.Red, mintCurrentX - 1, mintCurrentY - 1, 5, 5)
         Me.Invalidate()
         Do While mblnExit = False And mintCurrentX > 0 And mintCurrentX < mintFormWidth And mintCurrentY > 0 And mintCurrentY < mintFormHeight - 10
            Select Case True
               Case mobjFormBitmap.GetPixel(mintCurrentX, mintCurrentY + 5) = Color.FromArgb(255, 255, 255, 255)
                  mintCurrentY += 1
               Case Else
                  If mintXSpeed = 0 Then
                     Select Case True
                        Case mobjFormBitmap.GetPixel(mintCurrentX + 1, mintCurrentY + 4) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX += 1
                           mintXSpeed += 1
                        Case mobjFormBitmap.GetPixel(mintCurrentX - 1, mintCurrentY + 4) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX -= 1
                           mintXSpeed -= 1
                        Case Else
                           mblnExit = True
                     End Select
                  ElseIf mintXSpeed > 0 Then
                     Select Case True
                        Case mobjFormBitmap.GetPixel(mintCurrentX + 1, mintCurrentY + 4) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX += 1
                           mintXSpeed += 1
                        Case mobjFormBitmap.GetPixel(mintCurrentX + 1, mintCurrentY + 3) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX += 1
                           mintCurrentY -= 1
                           mintXSpeed -= 1
                        Case mobjFormBitmap.GetPixel(mintCurrentX + 1, mintCurrentY + 2) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX += 1
                           mintCurrentY -= 2
                           mintXSpeed -= 2
                        Case mobjFormBitmap.GetPixel(mintCurrentX + 1, mintCurrentY + 1) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX += 1
                           mintCurrentY -= 3
                           mintXSpeed -= 3
                        Case mobjFormBitmap.GetPixel(mintCurrentX + 1, mintCurrentY) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX += 1
                           mintCurrentY -= 4
                           mintXSpeed -= 4
                        Case mobjFormBitmap.GetPixel(mintCurrentX - 1, mintCurrentY + 4) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX -= 1
                           mintXSpeed = -5
                        Case mobjFormBitmap.GetPixel(mintCurrentX - 1, mintCurrentY + 3) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX -= 1
                           mintCurrentY -= 1
                           mintXSpeed = -5
                        Case Else
                           mblnExit = True
                     End Select
                  Else
                     Select Case True
                        Case mobjFormBitmap.GetPixel(mintCurrentX - 1, mintCurrentY + 4) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX -= 1
                           mintXSpeed -= 1
                        Case mobjFormBitmap.GetPixel(mintCurrentX - 1, mintCurrentY + 3) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX -= 1
                           mintCurrentY -= 1
                           mintXSpeed += 1
                        Case mobjFormBitmap.GetPixel(mintCurrentX - 1, mintCurrentY + 2) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX -= 1
                           mintCurrentY -= 2
                           mintXSpeed += 2
                        Case mobjFormBitmap.GetPixel(mintCurrentX - 1, mintCurrentY + 1) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX -= 1
                           mintCurrentY -= 3
                           mintXSpeed += 3
                        Case mobjFormBitmap.GetPixel(mintCurrentX - 1, mintCurrentY) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX -= 1
                           mintCurrentY -= 4
                           mintXSpeed += 4
                        Case mobjFormBitmap.GetPixel(mintCurrentX + 1, mintCurrentY + 4) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX += 1
                           mintXSpeed = 5
                        Case mobjFormBitmap.GetPixel(mintCurrentX + 1, mintCurrentY + 3) = Color.FromArgb(255, 255, 255, 255)
                           mintCurrentX += 1
                           mintCurrentY += 1
                           mintXSpeed = 5
                        Case Else
                           mblnExit = True
                     End Select

                  End If
            End Select

            mobjBitmapGraphics.FillEllipse(Brushes.White, mintPrevX - 1, mintPrevY - 1, 5, 5)

            mobjBitmapGraphics.FillEllipse(Brushes.Red, mintCurrentX - 1, mintCurrentY - 1, 5, 5)
            Me.Invalidate()

            mintPrevX = mintCurrentX
            mintPrevY = mintCurrentY

            Application.DoEvents()

         Loop

      End If

   End Sub

   Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

      If e.KeyCode = Keys.Escape Then
         mblnExit = True
      End If

   End Sub

   Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

      mblnExit = True

   End Sub

End Class



