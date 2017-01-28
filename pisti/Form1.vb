Public Class Form1

    'Korh@n GeRi� prestige 2005    
    'resimler picturebox lara yerle�tirilmi� ordan dizilere aktar�lm��t�r
    'path ten okutularak da yap�labilirdi..

#Region "global de�i�kenler"
    'random say� �reterek yeni kar��m�� bi deste �retilerek bu de�erler
    'kar��an kartlar dizisinde tutulucak
    Dim kar�san_kartlar(51) As Integer

    'kartlar i�in yeni matris bir dizi olu�tur
    'resim diziside matris olucak ve b�ylelikle ayn� matris de�erleri
    'ile hem resimleri hemde isimleri tutabilicem
    Dim kartlar(3, 12) As Integer

    'resimleri direk butonun �st�nde ��kartam�yorum ��nk� di�eroyuncular�n kartlar�
    'kapal� olmal� dolay�s�yla yeni bir image dizisi olu�turarak arka planda tutuyorum
    'b�ylece resimler butonun �st�nde olmasada sanki �st�ndeymi� gibi �a�r�ld���nda
    'yani yere at�laca��nda bu dizi kullan�larak yerdeki ka��t�n resmini de�i�tirebilicem
    Dim resim_degistir(51) As Image

    'her turda da��t�lan ka��d�n say�s�n�tutmam gerekiyor ki bidaki elde ka��nc� ka��ttan
    'da��tmaya ba�layaca��m� unutmayay�m
    Dim x As Integer = 0

    'yerdeki resim bo� oldu�unda pistimi de�i�keni o elde at�lan ka��d� tutuyor
    'b�ylece sonraki elde pistimi de�i�keni "" bo� de�ilse ve yeni at�lan ka��tla
    'ayn� olursa pi�ti oluyor bunu tutmak i�in bu de�i�keni kullan�yorum
    Dim pistimi As String

    'tasar�m an�nda yerde duran butonlar yani oyuncular�n ka��tlar�
    Dim buton_dizi(15) As Button

    'kartlar i�in olu�turdu�um matris dizide bahsetmi�tim bu da resimler i�in olan�
    Dim resimler(3, 12) As Image

    'ilk oyuna ba�layan oyuncu yani biz oldu�umuz i�in buton indexini 4 ten ba�latmam�z
    'gerekiyor ��nk� bizim ka��tlar�m�z 0,1,2 ve 3numaral� indexe sahipler..
    Dim tut As Integer = 4

    'puanlar�n tutulmas� ve ka��tlar� her ald���nda i�indeki puanl� ka��tlar�n
    'hesaplat�lmas� i�in bir arraylist tan�ml�yorum
    Dim puantut As New ArrayList()


#End Region

#Region "prosed�rler"
    ' ilk �nce ka��tlar� tan�ml�yorum b�ylece onlar� isimlendirebilicem 

    'numaras� isminde bir enum tan�mlayarak ka��t de�erleini yani numaralar�n� tutuyorum
    Public Enum numaras�
        bir = 0
        iki = 1
        uc = 2
        dort = 3
        bes = 4
        alt� = 5
        yedi = 6
        sekiz = 7
        dokuz = 8
        onlu = 9
        vale = 10
        k�z = 11
        papaz = 12
    End Enum

    'cesidi enumu ile de ka��t t�rlerini tutmu� oluyorum
    Public Enum cesidi
        sinek = 0
        kupa = 1
        maca = 2
        karo = 3
    End Enum

    '52 ka��t olu�turularak bu ka��tlara 1 den 52 e kadar de�er atamas� yap�l�yor
    Public Sub kartlar�_olustur()
        Dim k As Integer = 0
        Dim i, j As Integer
        For i = 0 To 3
            For j = 0 To 12
                'kartlar dizisine de�erleri aktar
                kartlar(i, j) = k
                'her turda de�eri bir artt�rmak i�in k local de�i�kenini kullan
                k += 1
            Next
        Next
    End Sub

    'at�lan ka��d�n ne oldu�unu anlamak i�in onlar� isimlendirmem gerekiyor
    'bunun i�in enum kulland�m ve a�a��da yazd���m iki prosed�r kulland�m
    'isimleri_yaz prosed�r� ile oyuncular�n ka��tlar�n� isimlendiriyorum
    'ilk �nce ilk 4 butonu yani bizim oynad���m�z butona yazd�r�yorum
    've onlara isimlerine kar��l�k gelen resimleri at�yorum
    'sonra di�er oyuncular�n ka��tlar� isimlendiriliyor
    'bunu yapabilmek i�in resimler matrisine ve kartlar matrisine ihtiyac�m war
    'i�te yukar�da tan�mlad���m iki matris bunun i�inde yani senkronize �al��abilmek i�in
    Public Sub isimleri_yaz()

        '�nce yerde bulunan ilk a��l��taki ka��d� g�r�n�r yap
        yer.Visible = True
        Dim h, i, j As Integer
        For h = 0 To 3
            'ilk 4 ka��t i�in bak
            For i = 0 To 3
                For j = 0 To 12
                    'butonun �st�nde yazan� kartlar dizisindeki kar��l�n� bul
                    'b�ylece resim atamas� yapabil
                    If (buton_dizi(h).Text = kartlar(i, j).ToString()) Then
                        Dim isim1, numara1 As String
                        isim1 = isim(i)
                        numara1 = numara(j)
                        buton_dizi(h).Text = isim1 + " " + numara1
                        buton_dizi(h).Image = resimler(i, j)
                    End If
                Next
            Next
        Next

        For h = 4 To 15
            For i = 0 To 3
                For j = 0 To 12
                    If (buton_dizi(h).Text = kartlar(i, j).ToString()) Then
                        Dim isim1, numara1 As String
                        'matris de�erlerini g�nder ve isimlendir
                        'kart tipini almak i�in prosed�r� �al��t�r
                        isim1 = isim(i)
                        'numaray� almak i�in prosed�r� �al��t�r
                        numara1 = numara(j)
                        'butonun �st�ne kart�n olu�turulan ad�n� yaz
                        buton_dizi(h).Text = isim1 + " " + numara1
                        'resmi ekle (matris de�erlerimiz ayn� oldu�u i�in)
                        buton_dizi(h).Image = arka_plan.Image
                        'resim de�i�tir dizisinde tut
                        resim_degistir(h) = resimler(i, j)
                    End If
                Next
            Next
        Next
    End Sub

    'isimleri_yaz prosed�r�nden �a�r�l�yor ve kart�n tipi ��reniliyor
    Public Function isim(ByVal kart_ismi As Integer) As String

        Dim ismi As String = ""
        Select Case (kart_ismi)
            'enumdan faydalan�larak bak
            Case cesidi.sinek
                ismi = cesidi.sinek.ToString
            Case cesidi.kupa
                ismi = cesidi.kupa.ToString
            Case cesidi.maca
                ismi = cesidi.maca.ToString
            Case cesidi.karo
                ismi = cesidi.karo.ToString
        End Select 've sonucu �a�r�ld��� yere geri d�nd�r...
        Return ismi

    End Function

    'isimleri_yaz prosed�r�nden �a�r�l�yor ve kart�n numaras� ��reniliyor
    Public Function numara(ByVal kart_numaras� As Integer) As String

        Dim numarali As String = ""
        Select Case (kart_numaras�)

            Case numaras�.bir
                numarali = numaras�.bir.ToString()
            Case numaras�.iki
                numarali = numaras�.iki.ToString()
            Case numaras�.uc
                numarali = numaras�.uc.ToString()
            Case numaras�.dort
                numarali = numaras�.dort.ToString()
            Case numaras�.bes
                numarali = numaras�.bes.ToString()
            Case numaras�.alt�
                numarali = numaras�.alt�.ToString()
            Case numaras�.yedi
                numarali = numaras�.yedi.ToString()
            Case numaras�.sekiz
                numarali = numaras�.sekiz.ToString()
            Case numaras�.dokuz
                numarali = numaras�.dokuz.ToString()
            Case numaras�.onlu
                numarali = numaras�.onlu.ToString()
            Case numaras�.vale
                numarali = numaras�.vale.ToString()
            Case numaras�.k�z
                numarali = numaras�.k�z.ToString()
            Case numaras�.papaz
                numarali = numaras�.papaz.ToString()
        End Select
        Return numarali
    End Function

    'resimler dizisine tasar�mda olu�turulmu� labellardan aktarma yap
    'asl�nda bu dosyadan okutularak ta yap�labilirdi ama anla��lmas� 
    've resimler dizisinin nas� olu�tu�unu g�rmek i�in elimizle yapt�k 
    've burada resimler matrisine aktarma yapt�k
    Public Sub resimleri_koy()

        resimler(0, 0) = sinek_1.Image
        resimler(0, 3) = sinek_4.Image
        resimler(0, 1) = sinek_2.Image
        resimler(0, 4) = sinek_5.Image
        resimler(0, 2) = sinek_3.Image
        resimler(0, 5) = sinek_6.Image
        resimler(0, 6) = sinek_7.Image
        resimler(0, 9) = sinek_10.Image
        resimler(0, 7) = sinek_8.Image
        resimler(0, 10) = sinek_vale.Image
        resimler(0, 8) = sinek_9.Image
        resimler(0, 11) = sinek_k�z.Image
        resimler(0, 12) = sinek_papaz.Image
        resimler(1, 0) = kupa_1.Image
        resimler(1, 3) = kupa_4.Image
        resimler(1, 1) = kupa_2.Image
        resimler(1, 4) = kupa_5.Image
        resimler(1, 2) = kupa_3.Image
        resimler(1, 5) = kupa_6.Image
        resimler(1, 6) = kupa_7.Image
        resimler(1, 9) = kupa_10.Image
        resimler(1, 7) = kupa_8.Image
        resimler(1, 10) = kupa_vale.Image
        resimler(1, 8) = kupa_9.Image
        resimler(1, 11) = kupa_k�z.Image
        resimler(1, 12) = kupa_papaz.Image
        resimler(2, 0) = maca_1.Image
        resimler(2, 3) = maca_4.Image
        resimler(2, 1) = maca_2.Image
        resimler(2, 4) = maca_5.Image
        resimler(2, 2) = maca_3.Image
        resimler(2, 5) = maca_6.Image
        resimler(2, 6) = maca_7.Image
        resimler(2, 9) = maca_10.Image
        resimler(2, 7) = maca_8.Image
        resimler(2, 10) = maca_vale.Image
        resimler(2, 8) = maca_9.Image
        resimler(2, 11) = maca_k�z.Image
        resimler(2, 12) = maca_papaz.Image
        resimler(3, 0) = karo_1.Image
        resimler(3, 3) = karo_4.Image
        resimler(3, 1) = karo_2.Image
        resimler(3, 4) = karo_5.Image
        resimler(3, 2) = karo_3.Image
        resimler(3, 5) = karo_6.Image
        resimler(3, 6) = karo_7.Image
        resimler(3, 9) = karo_10.Image
        resimler(3, 7) = karo_8.Image
        resimler(3, 10) = karo_vale.Image
        resimler(3, 8) = karo_9.Image
        resimler(3, 11) = karo_k�z.Image
        resimler(3, 12) = karo_papaz.Image
    End Sub

    'oyuncular�n oynayaca�� butonlar daha kolay �al��mak i�in diziye al�n�yor
    Public Sub butonlar�_koy()

        buton_dizi(0) = b1
        buton_dizi(1) = b2
        buton_dizi(2) = b3
        buton_dizi(3) = b4
        buton_dizi(4) = b5
        buton_dizi(5) = b6
        buton_dizi(6) = b7
        buton_dizi(7) = b8
        buton_dizi(8) = b9
        buton_dizi(9) = b10
        buton_dizi(10) = b11
        buton_dizi(11) = b12
        buton_dizi(12) = b13
        buton_dizi(13) = b14
        buton_dizi(14) = b15
        buton_dizi(15) = b16
    End Sub


    Public Sub kartlar�_kar�st�r()
        '0-51 aras� kar���k elemanl� bir dizi elde ettim

        Dim i, j As Integer
        For i = 0 To 51
            'random bir say� �retiliyor
            kar�san_kartlar(i) = Rnd() * 51
            For j = 0 To i - 1
                'daha �nce �retilenle ayn� varsa yeni �ret ve gei d�nerek kontrol et
                If (kar�san_kartlar(i) = kar�san_kartlar(j)) Then
                    kar�san_kartlar(i) = Rnd() * 51
                    'j de�eri -1 yap�larak i�teki d�ng�n�n tekrar �al��t�r�lmas� sa�lan�yor
                    j = -1
                End If
            Next
        Next
    End Sub

    'ka��tlar�n her turda butonlara da��t�m� i�in olu�turuldu
    'ayn� zamanda oyunun sonunun geldi�ini ve ka��tlar� isimlendirmek
    'i�inde burdan �a��r�mlarda bulunuyoruz
    Public Sub dag�t()

        Dim i, j, h As Integer
        For i = 0 To 15
            '�ncelikle oyuncular�n ka��tlar�n� g�r�n�r yap
            buton_dizi(i).Visible = True
        Next

        'e�er da��t�lan ilk ka��t ise
        If (x = 0) Then
            '48. kart� ortaya koy
            'yerdeki ka��tlar� g�r�n�r yap
            yer.Visible = True
            YER1.Visible = True
            YER2.Visible = True
            YER3.Visible = True

            'oyuna ba�lmadan �nce arraylist i (puanlar� tutan k�sm�) temizle
            puantut.Clear()

            'kolay �al��abilmek i�in yerde yani pi�tide a��lan ilk d�rt ka��d�
            'diziye al
            Dim yaz(3) As Button
            yaz(0) = yer
            yaz(1) = YER1
            yaz(2) = YER2
            yaz(3) = YER3

            'kar��an kartlardan son d�rt ka��t al�narak ortaya a��l�yor
            yer.Text = kar�san_kartlar(48).ToString()
            YER1.Text = kar�san_kartlar(49).ToString()
            YER2.Text = kar�san_kartlar(50).ToString()
            YER3.Text = kar�san_kartlar(51).ToString()

            For i = 0 To 3
                For j = 0 To 12
                    If (yer.Text = kartlar(i, j).ToString()) Then
                        'bu ka��tlar i�inde isim yaz�m� yap�l�yor
                        Dim isim1, numara1 As String
                        isim1 = isim(i)
                        numara1 = numara(j)
                        yer.Image = resimler(i, j)
                    End If
                Next
            Next

            For h = 0 To 3
                For i = 0 To 3
                    For j = 0 To 12
                        'isimleri_yaz prosed�r�ndeki ayn� mant�k
                        If (yaz(h).Text = kartlar(i, j).ToString()) Then

                            Dim isim1, numara1 As String
                            isim1 = isim(i)
                            numara1 = numara(j)
                            'burda dikkat edilecek bir konu  var ben butonlar�n text lerini
                            'kulland���m i�in ve yaz�lar�n g�z�kmesini istemedi�im i�in 
                            'butonlar�n �st�ndeki yaz�n�n numaras�n� k���ltt�m
                            'butonlar�n text de�erlerini kullanmamak i�in bir dizi kullan�labilirdi
                            've butonlarla senkronize �al��t�r�labilirdi yani resim_degistir
                            'dizisi ile yap�ld��� gibi bir yolda izlenebilirdi
                            yaz(h).Text = isim1 + " " + numara1
                            yaz(h).Font = New Font("Microsoft Sans Serif", 1, FontStyle.Regular)
                            yaz(h).ForeColor = Color.White
                        End If

                    Next
                Next
            Next

            'yerdeki 4 ka��ttan ���n�n arka plan g�r�nt�s�n� ka��t arkas� g�r�nt�s�
            'yap b�lece g�z�kmesin

            YER1.Image = arka_plan.Image
            YER2.Image = arka_plan.Image
            YER3.Image = arka_plan.Image

            'yerdeki ka��tlarda puan hesaplamas�nda puan de�eri ta��yabileceksay�lar olabilir
            'onun i�in bu d�ng� kurularak puan ta��yan ka��tlar arrayliste ekleniyor
            For h = 0 To 3

                Dim kag�t_numaras�n�_al As String = ""
                Dim tipi As String = ""
                'ka��t yaz�m� "kupa iki" gibi oldu�undan bo�luk bulunuyor ve bo�lu�un sa� ve sol taraf� 
                'kullan�l�yor ��nk� puanlamada hem tipi hemnumaras�laz�m
                Dim bosluk As Integer = yaz(h).Text.IndexOf(" ", 0)
                'sa� taraf� al
                kag�t_numaras�n�_al = yaz(h).Text.Substring(bosluk + 1, yaz(h).Text.Length - bosluk - 1)
                'sol taraf�al
                tipi = yaz(h).Text.Substring(0, bosluk)
                'puan� hesaplamak i�in prosed�re g�nder
                Dim deger As Integer = puan(kag�t_numaras�n�_al, tipi)
                'arrayliste ekle
                puantut.Add(deger)

            Next

            'yerdeki 4 ka��ttan birini a�mal�y�z bunun i�in o ka��d�n ad�n� �stteki gibi
            'kartlar matrisi yard�m�yla resimler matrisinden resmini buluyorum
            For i = 0 To 3

                For j = 0 To 12

                    If (yer.Text = kartlar(i, j).ToString()) Then

                        Dim isim1, numara1 As String
                        isim1 = isim(i)
                        numara1 = numara(j)
                        yer.Text = isim1 + " " + numara1
                        yer.Image = resimler(i, j)
                    End If
                Next
            Next

            'x 48 oldu�unda oyun biter
        ElseIf (x = 48) Then
            'oyun bitti
            MessageBox.Show("oyun bitti")

            'puanlar� toplayarak gitmek i�in de�i�kenler tan�mla
            Dim list1 As Integer = 0
            Dim list2 As Integer = 0
            Dim list3 As Integer = 0
            Dim list4 As Integer = 0

            '�nce listbox1 deki toplam� al
            For i = 0 To listBox1.Items.Count - 1

                list1 += Convert.ToInt32(listBox1.Items(i))
            Next
            'listbox1 i temizle
            listBox1.Items.Clear()
            'toplam� ekle
            listBox1.Items.Add(list1)

            'di�er listboxlar i�inde yap
            For i = 0 To listBox2.Items.Count - 1

                list2 += Convert.ToInt32(listBox2.Items(i))
            Next
            listBox2.Items.Clear()
            listBox2.Items.Add(list2)

            For i = 0 To listBox3.Items.Count - 1

                list3 += Convert.ToInt32(listBox3.Items(i))
            Next
            listBox3.Items.Clear()
            listBox3.Items.Add(list3)

            For i = 0 To listBox4.Items.Count - 1

                list4 += Convert.ToInt32(listBox4.Items(i))
            Next
            listBox4.Items.Clear()
            listBox4.Items.Add(list4)

            'yerdeki ka��tlar�n g�r�n�rl���n� kapat yeni oyun i�in yap�ld�
            yer.Visible = False
            YER1.Visible = False
            YER2.Visible = False
            YER3.Visible = False

            For i = 0 To 15
                'yeni oyun i�in oyuncu ka��tlar�n�n g�r�n�rl���n� kapat
                buton_dizi(i).Visible = False
            Next
            For i = 0 To 3

                'bizimka��tlar�n click eventini �al��t�rmam�z� engelle
                buton_dizi(i).Enabled = False
            Next

            'yeni oyun i�in kar��t�r butonunu aktifle�tir da��t butonunu kapat
            button9.Enabled = False
            button10.Enabled = True

            'ka��t da��t�m say�s�n� tekrar s�f�ra al
            x = 0
            Return
        End If
        For i = 0 To 3

            buton_dizi(i).Enabled = True
        Next
        For i = 0 To 15

            buton_dizi(i).Text = kar�san_kartlar(x).ToString()
            x += 1
        Next

        'isimleri yazd�rabilmek i�in tekrar isimleri_yaz prosedr�n� �a��r
        'b�ylece her ka��t da��t�m elinde yazd�rm�� oluyoruz
        isimleri_yaz()

    End Sub

    Dim pisti As String = "dene"

    Private Sub oynat()

        'buras� b1 click ten �a�r�l�yor 1.oyuncu oynad�ktan sonra di�er oyuncular�n 
        'oynamas� i�in bu prosed�r kullan�lacak
        Dim kag�t_numaras�n�_al As String = ""
        Dim kag�t_numaras�n�_al1 As String = ""
        Dim tipi As String = ""
        Dim sayac, i, k, bak As Integer
        '3 kere �al��t�r�cam ��nk� bizim d���m�zda 3 tane daha oyuncu war
        For sayac = 0 To 2
            'tut de�i�keni ile geriye kalan 3 oyuncunun elindeki ka��tlara ula��yorum
            For i = tut To tut + 3
                'e�er ka��t oynanmam��sa
                If (buton_dizi(i).Visible = True) Then
                    '�nce bas�lan ka��d�n ne oldu�una bak�cam
                    Dim bosluk As Integer = buton_dizi(i).Text.IndexOf(" ", 0)
                    kag�t_numaras�n�_al = buton_dizi(i).Text.Substring(bosluk + 1, buton_dizi(i).Text.Length - bosluk - 1)
                    tipi = buton_dizi(i).Text.Substring(0, bosluk)

                    'yerdeki ka��t�n ne oldu�u al�n�yor
                    Dim bosluk1 As Integer = yer.Text.IndexOf(" ", 0)
                    kag�t_numaras�n�_al1 = yer.Text.Substring(bosluk1 + 1, yer.Text.Length - bosluk1 - 1)

                    'pi�ti olup olmad���na bak
                    If ((kag�t_numaras�n�_al = kag�t_numaras�n�_al1) And (pistimi <> "")) Then

                        'pi�tiyse yapan oyuncuya 10 puan ekle
                        MessageBox.Show("pisti oldu")
                        If (sayac = 0) Then
                            'sayuac 0 ikinci oyuncuyu
                            listBox2.Items.Add(10)

                        ElseIf (sayac = 1) Then
                            'sayac 1 ���nc� oyuncuyu
                            listBox3.Items.Add(10)

                        ElseIf (sayac = 2) Then

                            'sayac2 d�rd�nc� oyuncuyu g�steriyor
                            listBox4.Items.Add(10)
                        End If

                    End If

                    'ka��d� alabilmesi i�in ya ayn� ka��t at�lmal� yada vale at�lmal�
                    If ((kag�t_numaras�n�_al = kag�t_numaras�n�_al1) Or (kag�t_numaras�n�_al = "vale")) Then

                        Dim deger As Integer = puan(kag�t_numaras�n�_al, tipi)
                        puantut.Add(deger)

                        'yerdeki ka��tlar al�nca yer deki ka��d� bo�alt
                        Dim bos As Image
                        yer.Image = bos
                        yer.Text = ""
                        buton_dizi(i).Visible = False
                        YER1.Visible = False
                        Dim toplam As Integer = 0

                        'arraylist in i�indeki de�erleri topla
                        For k = 0 To puantut.Count - 1
                            toplam += Convert.ToInt32(puantut(k))
                        Next
                        'arraylisti temizle
                        puantut.Clear()

                        'sayac a g�re puanlar� kime ekleyece�ine karar wer
                        '0 birinci oyuncuyu 1 ikinci oyuncuyu 2���nc� oyuncuyu ifade ediyor
                        If (sayac = 0) Then
                            listBox2.Items.Add(toplam)
                        ElseIf (sayac = 1) Then
                            listBox3.Items.Add(toplam)
                        ElseIf (sayac = 2) Then
                            listBox4.Items.Add(toplam)
                        End If

                        pisti = ""
                        YER2.Visible = False
                        YER3.Visible = False
                        Exit For
                    End If
                End If


                'yani ayn�s�ndan bulamam��sa
                If (i = tut + 3) Then
                    'g�r�n�r yani kullan�lmam�� ka��tlar aras�ndan birini se�
                    've yere at
                    For bak = i - 3 To i
                        If (buton_dizi(bak).Visible = True) Then
                            yer.Image = resim_degistir(bak)
                            yer.Text = buton_dizi(bak).Text

                            buton_dizi(bak).Visible = False
                            bak = i + 1
                            If (pisti = "") Then
                                pistimi = yer.Text
                            Else
                                pistimi = ""
                            End If
                            'her turda arraylist e eklenmesi sa�lan�yor
                            Dim deger As Integer = puan(kag�t_numaras�n�_al, tipi)
                            puantut.Add(deger)

                            Me.Refresh()
                            System.Threading.Thread.Sleep(1000)

                            pisti = "dene"
                            Exit For
                        End If
                    Next
                Else
                    Continue For
                End If
            Next
            'di�er oyuncular�n ka��tlar�na ula�abilmek i�in her turda tut de�i�keni artt�r�l�yor
            tut += 4
        Next
    End Sub

    'oyunu ba�latma i�in �al��t�r�yorum.. Diziler tan�mlan�yor ve elemanlar s�f�rlan�yor
    Private Sub oyunu_ba�lat()

        Dim i As Integer
        'puanlar�n tutuldu�un yeri yani listboxlar� s��frla
        listBox1.Items.Clear()
        listBox2.Items.Clear()
        listBox3.Items.Clear()
        listBox4.Items.Clear()

        'yerdeki kapal� 3ka��d�n resimlerini olu�tur 
        YER1.Image = arka_plan.Image
        YER2.Image = arka_plan.Image
        YER3.Image = arka_plan.Image
        yer.Enabled = False

        'prosed�rler �a�r�larak elemanlar�n dizilere aktar�lmas� sa�lan�yor
        kartlar�_olustur()
        butonlar�_koy()
        resimleri_koy()

        'oyuncular�n ka��tlar� ile ilgili ayarlar� yap
        For i = 0 To 15

            'resimlerini olu�tur,, ba�ta hepsi arka plan format�nda g�r�ns�n
            buton_dizi(i).Image = arka_plan.Image
            'g�r�n�r yap
            buton_dizi(i).Visible = True
        Next

        YER1.Visible = True
        YER2.Visible = True
        YER3.Visible = True
        button10.Enabled = True
        button9.Enabled = False
    End Sub

    'puan functionu sayesinde g�nderilen ka��d�n puanlanmas� yap�l�p �a�r�ld��� yere geri g�nderiliyor
    Public Function puan(ByVal kagit_numarasi As String, ByVal tipi As String) As Integer

        If ((kagit_numarasi = "bir") Or (kagit_numarasi = "vale")) Then
            Return 1
        ElseIf ((kagit_numarasi = "iki") And (tipi = "sinek")) Then
            Return 2
        ElseIf ((kagit_numarasi = "onlu") And (tipi = "karo")) Then
            Return 3
        Else
            Return 0
        End If
    End Function

#End Region


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'oyuncu adlar�n g�sterilece�i labellara isimleri yaz
        label2.Text = toolStripTextBox1.Text
        label3.Text = toolStripTextBox2.Text
        label4.Text = toolStripTextBox3.Text
        label5.Text = toolStripTextBox4.Text

        label6.Text = toolStripTextBox1.Text
        label7.Text = toolStripTextBox2.Text
        label8.Text = toolStripTextBox3.Text
        label9.Text = toolStripTextBox4.Text

        oyunu_ba�lat()

        'butonlar�n textinde yaz� g�z�kmemesi i�in yaz�y� k���ltt�m
        Dim i As Integer
        For i = 0 To 15
            buton_dizi(i).Font = New Font("Microsoft Sans Serif", 1, FontStyle.Regular)
            buton_dizi(i).ForeColor = Color.White
        Next
    End Sub

    Private Sub button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button10.Click
        'ka��tlar kar��t�r�l�yor ve oyuncu ka��tlar� g�r�n�ryap�l�yor
        x = 0
        kartlar�_kar�st�r()
        button10.Enabled = False
        button9.Enabled = True
        Dim i As Integer
        For i = 0 To 15
            buton_dizi(i).Visible = True
        Next
    End Sub

    Private Sub button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button9.Click
        'ka��tlar da��t�l�yor
        button10.Enabled = False
        dag�t()
    End Sub

    Private Sub b1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b1.Click, b2.Click, b3.Click, b4.Click
        'bizim att���m�z ka��tlar i�in
        tut = 0 'di�er oyuncular�n oynamas� i�in tan�mland� yukar�da a��klamas� var
        'buton 1,2,3,4 i buraya ba�la
        Dim i As Integer
        Dim yeni As Button
        For i = 0 To 3
            'buton 1,2,3,4 mi diye bak�l�yor
            If (sender Is buton_dizi(i)) Then
                'e�er yerdekiyle tutmuyosa yere onu koy ve visible �n� false yap
                yeni = buton_dizi(i)
            End If
        Next

        Dim bosluk As Integer = yeni.Text.IndexOf(" ", 0)  'bo�lu�un ka��nc� karakter oldu�una bak�yorum
        Dim tipi As String = yeni.Text.Substring(0, bosluk)
        Dim kag�t_numaras�n�_al As String = "" 'at�lan ka��d�n ne oldu�una bak�cam



        'kupa m� sinek mi oldu�u ile ilgilenmiyorum
        'say�s� �nemli o y�zden bo�luktan sonras�n� keserek al�cam
        kag�t_numaras�n�_al = yeni.Text.Substring(bosluk + 1, yeni.Text.Length - bosluk - 1)

        Dim deger As Integer = puan(kag�t_numaras�n�_al, tipi)
        puantut.Add(deger)

        Dim bosluk1 As Integer = yer.Text.IndexOf(" ", 0)
        Dim kag�t_numaras�n�_al1 As String
        kag�t_numaras�n�_al1 = yer.Text.Substring(bosluk1 + 1, yer.Text.Length - bosluk1 - 1)

        If ((kag�t_numaras�n�_al = kag�t_numaras�n�_al1) And (pistimi <> "")) Then
            MessageBox.Show("pisti oldu")
            listBox1.Items.Add(10)
        End If
        pisti = "dene"

        If ((kag�t_numaras�n�_al = kag�t_numaras�n�_al1) Or (kag�t_numaras�n�_al = "vale")) Then

            Dim toplam As Integer = 0
            For i = 0 To puantut.Count - 1
                toplam += Convert.ToInt32(puantut(i))
            Next
            listBox1.Items.Add(toplam)
            puantut.Clear()
            pisti = ""
            Dim bos As Image
            yer.Image = bos
            YER1.Visible = False
            YER2.Visible = False
            YER3.Visible = False
        Else
            yer.Image = yeni.Image
        End If
        'this.Text = kag�t_numaras�n�_al 

        yer.Text = yeni.Text


        yeni.Visible = False
        'oynad�ktan sonra di�erlerine oynat
        tut = 4

        Me.Refresh()
        System.Threading.Thread.Sleep(1500)
        oynat()
    End Sub

    'men�den isimler de�i�tirilir de�i�tirmez labellara aktar..
    Private Sub toolStripTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolStripTextBox1.TextChanged
        label6.Text = toolStripTextBox1.Text
        label2.Text = toolStripTextBox1.Text
    End Sub

    Private Sub toolStripTextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolStripTextBox2.TextChanged
        label7.Text = toolStripTextBox2.Text
        label3.Text = toolStripTextBox2.Text
    End Sub

    Private Sub toolStripTextBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolStripTextBox3.TextChanged

        label8.Text = toolStripTextBox3.Text
        label4.Text = toolStripTextBox3.Text
    End Sub

    Private Sub toolStripTextBox4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolStripTextBox4.TextChanged
        label9.Text = toolStripTextBox4.Text
        label5.Text = toolStripTextBox4.Text
    End Sub

    Private Sub yenioyunToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles yenioyunToolStripMenuItem.Click
        oyunu_ba�lat()
    End Sub
End Class
