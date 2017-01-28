Public Class Form1

    'Korh@n GeRiÞ prestige 2005    
    'resimler picturebox lara yerleþtirilmiþ ordan dizilere aktarýlmýþtýr
    'path ten okutularak da yapýlabilirdi..

#Region "global deðiþkenler"
    'random sayý üreterek yeni karýþmýþ bi deste üretilerek bu deðerler
    'karýþan kartlar dizisinde tutulucak
    Dim karýsan_kartlar(51) As Integer

    'kartlar için yeni matris bir dizi oluþtur
    'resim diziside matris olucak ve böylelikle ayný matris deðerleri
    'ile hem resimleri hemde isimleri tutabilicem
    Dim kartlar(3, 12) As Integer

    'resimleri direk butonun üstünde çýkartamýyorum çünkü diðeroyuncularýn kartlarý
    'kapalý olmalý dolayýsýyla yeni bir image dizisi oluþturarak arka planda tutuyorum
    'böylece resimler butonun üstünde olmasada sanki üstündeymiþ gibi çaðrýldýðýnda
    'yani yere atýlacaðýnda bu dizi kullanýlarak yerdeki kaðýtýn resmini deðiþtirebilicem
    Dim resim_degistir(51) As Image

    'her turda daðýtýlan kaðýdýn sayýsýnýtutmam gerekiyor ki bidaki elde kaçýncý kaðýttan
    'daðýtmaya baþlayacaðýmý unutmayayým
    Dim x As Integer = 0

    'yerdeki resim boþ olduðunda pistimi deðiþkeni o elde atýlan kaðýdý tutuyor
    'böylece sonraki elde pistimi deðiþkeni "" boþ deðilse ve yeni atýlan kaðýtla
    'ayný olursa piþti oluyor bunu tutmak için bu deðiþkeni kullanýyorum
    Dim pistimi As String

    'tasarým anýnda yerde duran butonlar yani oyuncularýn kaðýtlarý
    Dim buton_dizi(15) As Button

    'kartlar için oluþturduðum matris dizide bahsetmiþtim bu da resimler için olaný
    Dim resimler(3, 12) As Image

    'ilk oyuna baþlayan oyuncu yani biz olduðumuz için buton indexini 4 ten baþlatmamýz
    'gerekiyor çünkü bizim kaðýtlarýmýz 0,1,2 ve 3numaralý indexe sahipler..
    Dim tut As Integer = 4

    'puanlarýn tutulmasý ve kaðýtlarý her aldýðýnda içindeki puanlý kaðýtlarýn
    'hesaplatýlmasý için bir arraylist tanýmlýyorum
    Dim puantut As New ArrayList()


#End Region

#Region "prosedürler"
    ' ilk önce kaðýtlarý tanýmlýyorum böylece onlarý isimlendirebilicem 

    'numarasý isminde bir enum tanýmlayarak kaðýt deðerleini yani numaralarýný tutuyorum
    Public Enum numarasý
        bir = 0
        iki = 1
        uc = 2
        dort = 3
        bes = 4
        altý = 5
        yedi = 6
        sekiz = 7
        dokuz = 8
        onlu = 9
        vale = 10
        kýz = 11
        papaz = 12
    End Enum

    'cesidi enumu ile de kaðýt türlerini tutmuþ oluyorum
    Public Enum cesidi
        sinek = 0
        kupa = 1
        maca = 2
        karo = 3
    End Enum

    '52 kaðýt oluþturularak bu kaðýtlara 1 den 52 e kadar deðer atamasý yapýlýyor
    Public Sub kartlarý_olustur()
        Dim k As Integer = 0
        Dim i, j As Integer
        For i = 0 To 3
            For j = 0 To 12
                'kartlar dizisine deðerleri aktar
                kartlar(i, j) = k
                'her turda deðeri bir arttýrmak için k local deðiþkenini kullan
                k += 1
            Next
        Next
    End Sub

    'atýlan kaðýdýn ne olduðunu anlamak için onlarý isimlendirmem gerekiyor
    'bunun için enum kullandým ve aþaðýda yazdýðým iki prosedür kullandým
    'isimleri_yaz prosedürü ile oyuncularýn kaðýtlarýný isimlendiriyorum
    'ilk önce ilk 4 butonu yani bizim oynadýðýmýz butona yazdýrýyorum
    've onlara isimlerine karþýlýk gelen resimleri atýyorum
    'sonra diðer oyuncularýn kaðýtlarý isimlendiriliyor
    'bunu yapabilmek için resimler matrisine ve kartlar matrisine ihtiyacým war
    'iþte yukarýda tanýmladýðým iki matris bunun içinde yani senkronize çalýþabilmek için
    Public Sub isimleri_yaz()

        'önce yerde bulunan ilk açýlýþtaki kaðýdý görünür yap
        yer.Visible = True
        Dim h, i, j As Integer
        For h = 0 To 3
            'ilk 4 kaðýt için bak
            For i = 0 To 3
                For j = 0 To 12
                    'butonun üstünde yazaný kartlar dizisindeki karþýlýný bul
                    'böylece resim atamasý yapabil
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
                        'matris deðerlerini gönder ve isimlendir
                        'kart tipini almak için prosedürü çalýþtýr
                        isim1 = isim(i)
                        'numarayý almak için prosedürü çalýþtýr
                        numara1 = numara(j)
                        'butonun üstüne kartýn oluþturulan adýný yaz
                        buton_dizi(h).Text = isim1 + " " + numara1
                        'resmi ekle (matris deðerlerimiz ayný olduðu için)
                        buton_dizi(h).Image = arka_plan.Image
                        'resim deðiþtir dizisinde tut
                        resim_degistir(h) = resimler(i, j)
                    End If
                Next
            Next
        Next
    End Sub

    'isimleri_yaz prosedüründen çaðrýlýyor ve kartýn tipi öðreniliyor
    Public Function isim(ByVal kart_ismi As Integer) As String

        Dim ismi As String = ""
        Select Case (kart_ismi)
            'enumdan faydalanýlarak bak
            Case cesidi.sinek
                ismi = cesidi.sinek.ToString
            Case cesidi.kupa
                ismi = cesidi.kupa.ToString
            Case cesidi.maca
                ismi = cesidi.maca.ToString
            Case cesidi.karo
                ismi = cesidi.karo.ToString
        End Select 've sonucu çaðrýldýðý yere geri döndür...
        Return ismi

    End Function

    'isimleri_yaz prosedüründen çaðrýlýyor ve kartýn numarasý öðreniliyor
    Public Function numara(ByVal kart_numarasý As Integer) As String

        Dim numarali As String = ""
        Select Case (kart_numarasý)

            Case numarasý.bir
                numarali = numarasý.bir.ToString()
            Case numarasý.iki
                numarali = numarasý.iki.ToString()
            Case numarasý.uc
                numarali = numarasý.uc.ToString()
            Case numarasý.dort
                numarali = numarasý.dort.ToString()
            Case numarasý.bes
                numarali = numarasý.bes.ToString()
            Case numarasý.altý
                numarali = numarasý.altý.ToString()
            Case numarasý.yedi
                numarali = numarasý.yedi.ToString()
            Case numarasý.sekiz
                numarali = numarasý.sekiz.ToString()
            Case numarasý.dokuz
                numarali = numarasý.dokuz.ToString()
            Case numarasý.onlu
                numarali = numarasý.onlu.ToString()
            Case numarasý.vale
                numarali = numarasý.vale.ToString()
            Case numarasý.kýz
                numarali = numarasý.kýz.ToString()
            Case numarasý.papaz
                numarali = numarasý.papaz.ToString()
        End Select
        Return numarali
    End Function

    'resimler dizisine tasarýmda oluþturulmuþ labellardan aktarma yap
    'aslýnda bu dosyadan okutularak ta yapýlabilirdi ama anlaþýlmasý 
    've resimler dizisinin nasý oluþtuðunu görmek için elimizle yaptýk 
    've burada resimler matrisine aktarma yaptýk
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
        resimler(0, 11) = sinek_kýz.Image
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
        resimler(1, 11) = kupa_kýz.Image
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
        resimler(2, 11) = maca_kýz.Image
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
        resimler(3, 11) = karo_kýz.Image
        resimler(3, 12) = karo_papaz.Image
    End Sub

    'oyuncularýn oynayacaðý butonlar daha kolay çalýþmak için diziye alýnýyor
    Public Sub butonlarý_koy()

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


    Public Sub kartlarý_karýstýr()
        '0-51 arasý karýþýk elemanlý bir dizi elde ettim

        Dim i, j As Integer
        For i = 0 To 51
            'random bir sayý üretiliyor
            karýsan_kartlar(i) = Rnd() * 51
            For j = 0 To i - 1
                'daha önce üretilenle ayný varsa yeni üret ve gei dönerek kontrol et
                If (karýsan_kartlar(i) = karýsan_kartlar(j)) Then
                    karýsan_kartlar(i) = Rnd() * 51
                    'j deðeri -1 yapýlarak içteki döngünün tekrar çalýþtýrýlmasý saðlanýyor
                    j = -1
                End If
            Next
        Next
    End Sub

    'kaðýtlarýn her turda butonlara daðýtýmý için oluþturuldu
    'ayný zamanda oyunun sonunun geldiðini ve kaðýtlarý isimlendirmek
    'içinde burdan çaðýrýmlarda bulunuyoruz
    Public Sub dagýt()

        Dim i, j, h As Integer
        For i = 0 To 15
            'öncelikle oyuncularýn kaðýtlarýný görünür yap
            buton_dizi(i).Visible = True
        Next

        'eðer daðýtýlan ilk kaðýt ise
        If (x = 0) Then
            '48. kartý ortaya koy
            'yerdeki kaðýtlarý görünür yap
            yer.Visible = True
            YER1.Visible = True
            YER2.Visible = True
            YER3.Visible = True

            'oyuna baþlmadan önce arraylist i (puanlarý tutan kýsmý) temizle
            puantut.Clear()

            'kolay çalýþabilmek için yerde yani piþtide açýlan ilk dört kaðýdý
            'diziye al
            Dim yaz(3) As Button
            yaz(0) = yer
            yaz(1) = YER1
            yaz(2) = YER2
            yaz(3) = YER3

            'karýþan kartlardan son dört kaðýt alýnarak ortaya açýlýyor
            yer.Text = karýsan_kartlar(48).ToString()
            YER1.Text = karýsan_kartlar(49).ToString()
            YER2.Text = karýsan_kartlar(50).ToString()
            YER3.Text = karýsan_kartlar(51).ToString()

            For i = 0 To 3
                For j = 0 To 12
                    If (yer.Text = kartlar(i, j).ToString()) Then
                        'bu kaðýtlar içinde isim yazýmý yapýlýyor
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
                        'isimleri_yaz prosedüründeki ayný mantýk
                        If (yaz(h).Text = kartlar(i, j).ToString()) Then

                            Dim isim1, numara1 As String
                            isim1 = isim(i)
                            numara1 = numara(j)
                            'burda dikkat edilecek bir konu  var ben butonlarýn text lerini
                            'kullandýðým için ve yazýlarýn gözükmesini istemediðim için 
                            'butonlarýn üstündeki yazýnýn numarasýný küçülttüm
                            'butonlarýn text deðerlerini kullanmamak için bir dizi kullanýlabilirdi
                            've butonlarla senkronize çalýþtýrýlabilirdi yani resim_degistir
                            'dizisi ile yapýldýðý gibi bir yolda izlenebilirdi
                            yaz(h).Text = isim1 + " " + numara1
                            yaz(h).Font = New Font("Microsoft Sans Serif", 1, FontStyle.Regular)
                            yaz(h).ForeColor = Color.White
                        End If

                    Next
                Next
            Next

            'yerdeki 4 kaðýttan üçünün arka plan görüntüsünü kaðýt arkasý görüntüsü
            'yap bölece gözükmesin

            YER1.Image = arka_plan.Image
            YER2.Image = arka_plan.Image
            YER3.Image = arka_plan.Image

            'yerdeki kaðýtlarda puan hesaplamasýnda puan deðeri taþýyabileceksayýlar olabilir
            'onun için bu döngü kurularak puan taþýyan kaðýtlar arrayliste ekleniyor
            For h = 0 To 3

                Dim kagýt_numarasýný_al As String = ""
                Dim tipi As String = ""
                'kaðýt yazýmý "kupa iki" gibi olduðundan boþluk bulunuyor ve boþluðun sað ve sol tarafý 
                'kullanýlýyor çünkü puanlamada hem tipi hemnumarasýlazým
                Dim bosluk As Integer = yaz(h).Text.IndexOf(" ", 0)
                'sað tarafý al
                kagýt_numarasýný_al = yaz(h).Text.Substring(bosluk + 1, yaz(h).Text.Length - bosluk - 1)
                'sol tarafýal
                tipi = yaz(h).Text.Substring(0, bosluk)
                'puaný hesaplamak için prosedüre gönder
                Dim deger As Integer = puan(kagýt_numarasýný_al, tipi)
                'arrayliste ekle
                puantut.Add(deger)

            Next

            'yerdeki 4 kaðýttan birini açmalýyýz bunun için o kaðýdýn adýný üstteki gibi
            'kartlar matrisi yardýmýyla resimler matrisinden resmini buluyorum
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

            'x 48 olduðunda oyun biter
        ElseIf (x = 48) Then
            'oyun bitti
            MessageBox.Show("oyun bitti")

            'puanlarý toplayarak gitmek için deðiþkenler tanýmla
            Dim list1 As Integer = 0
            Dim list2 As Integer = 0
            Dim list3 As Integer = 0
            Dim list4 As Integer = 0

            'önce listbox1 deki toplamý al
            For i = 0 To listBox1.Items.Count - 1

                list1 += Convert.ToInt32(listBox1.Items(i))
            Next
            'listbox1 i temizle
            listBox1.Items.Clear()
            'toplamý ekle
            listBox1.Items.Add(list1)

            'diðer listboxlar içinde yap
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

            'yerdeki kaðýtlarýn görünürlüðünü kapat yeni oyun için yapýldý
            yer.Visible = False
            YER1.Visible = False
            YER2.Visible = False
            YER3.Visible = False

            For i = 0 To 15
                'yeni oyun için oyuncu kaðýtlarýnýn görünürlüðünü kapat
                buton_dizi(i).Visible = False
            Next
            For i = 0 To 3

                'bizimkaðýtlarýn click eventini çalýþtýrmamýzý engelle
                buton_dizi(i).Enabled = False
            Next

            'yeni oyun için karýþtýr butonunu aktifleþtir daðýt butonunu kapat
            button9.Enabled = False
            button10.Enabled = True

            'kaðýt daðýtým sayýsýný tekrar sýfýra al
            x = 0
            Return
        End If
        For i = 0 To 3

            buton_dizi(i).Enabled = True
        Next
        For i = 0 To 15

            buton_dizi(i).Text = karýsan_kartlar(x).ToString()
            x += 1
        Next

        'isimleri yazdýrabilmek için tekrar isimleri_yaz prosedrünü çaðýr
        'böylece her kaðýt daðýtým elinde yazdýrmýþ oluyoruz
        isimleri_yaz()

    End Sub

    Dim pisti As String = "dene"

    Private Sub oynat()

        'burasý b1 click ten çaðrýlýyor 1.oyuncu oynadýktan sonra diðer oyuncularýn 
        'oynamasý için bu prosedür kullanýlacak
        Dim kagýt_numarasýný_al As String = ""
        Dim kagýt_numarasýný_al1 As String = ""
        Dim tipi As String = ""
        Dim sayac, i, k, bak As Integer
        '3 kere çalýþtýrýcam çünkü bizim dýþýmýzda 3 tane daha oyuncu war
        For sayac = 0 To 2
            'tut deðiþkeni ile geriye kalan 3 oyuncunun elindeki kaðýtlara ulaþýyorum
            For i = tut To tut + 3
                'eðer kaðýt oynanmamýþsa
                If (buton_dizi(i).Visible = True) Then
                    'önce basýlan kaðýdýn ne olduðuna bakýcam
                    Dim bosluk As Integer = buton_dizi(i).Text.IndexOf(" ", 0)
                    kagýt_numarasýný_al = buton_dizi(i).Text.Substring(bosluk + 1, buton_dizi(i).Text.Length - bosluk - 1)
                    tipi = buton_dizi(i).Text.Substring(0, bosluk)

                    'yerdeki kaðýtýn ne olduðu alýnýyor
                    Dim bosluk1 As Integer = yer.Text.IndexOf(" ", 0)
                    kagýt_numarasýný_al1 = yer.Text.Substring(bosluk1 + 1, yer.Text.Length - bosluk1 - 1)

                    'piþti olup olmadýðýna bak
                    If ((kagýt_numarasýný_al = kagýt_numarasýný_al1) And (pistimi <> "")) Then

                        'piþtiyse yapan oyuncuya 10 puan ekle
                        MessageBox.Show("pisti oldu")
                        If (sayac = 0) Then
                            'sayuac 0 ikinci oyuncuyu
                            listBox2.Items.Add(10)

                        ElseIf (sayac = 1) Then
                            'sayac 1 üçüncü oyuncuyu
                            listBox3.Items.Add(10)

                        ElseIf (sayac = 2) Then

                            'sayac2 dördüncü oyuncuyu gösteriyor
                            listBox4.Items.Add(10)
                        End If

                    End If

                    'kaðýdý alabilmesi için ya ayný kaðýt atýlmalý yada vale atýlmalý
                    If ((kagýt_numarasýný_al = kagýt_numarasýný_al1) Or (kagýt_numarasýný_al = "vale")) Then

                        Dim deger As Integer = puan(kagýt_numarasýný_al, tipi)
                        puantut.Add(deger)

                        'yerdeki kaðýtlar alýnca yer deki kaðýdý boþalt
                        Dim bos As Image
                        yer.Image = bos
                        yer.Text = ""
                        buton_dizi(i).Visible = False
                        YER1.Visible = False
                        Dim toplam As Integer = 0

                        'arraylist in içindeki deðerleri topla
                        For k = 0 To puantut.Count - 1
                            toplam += Convert.ToInt32(puantut(k))
                        Next
                        'arraylisti temizle
                        puantut.Clear()

                        'sayac a göre puanlarý kime ekleyeceðine karar wer
                        '0 birinci oyuncuyu 1 ikinci oyuncuyu 2üçüncü oyuncuyu ifade ediyor
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


                'yani aynýsýndan bulamamýþsa
                If (i = tut + 3) Then
                    'görünür yani kullanýlmamýþ kaðýtlar arasýndan birini seç
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
                            'her turda arraylist e eklenmesi saðlanýyor
                            Dim deger As Integer = puan(kagýt_numarasýný_al, tipi)
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
            'diðer oyuncularýn kaðýtlarýna ulaþabilmek için her turda tut deðiþkeni arttýrýlýyor
            tut += 4
        Next
    End Sub

    'oyunu baþlatma için çalýþtýrýyorum.. Diziler tanýmlanýyor ve elemanlar sýfýrlanýyor
    Private Sub oyunu_baþlat()

        Dim i As Integer
        'puanlarýn tutulduðun yeri yani listboxlarý sýýfrla
        listBox1.Items.Clear()
        listBox2.Items.Clear()
        listBox3.Items.Clear()
        listBox4.Items.Clear()

        'yerdeki kapalý 3kaðýdýn resimlerini oluþtur 
        YER1.Image = arka_plan.Image
        YER2.Image = arka_plan.Image
        YER3.Image = arka_plan.Image
        yer.Enabled = False

        'prosedürler çaðrýlarak elemanlarýn dizilere aktarýlmasý saðlanýyor
        kartlarý_olustur()
        butonlarý_koy()
        resimleri_koy()

        'oyuncularýn kaðýtlarý ile ilgili ayarlarý yap
        For i = 0 To 15

            'resimlerini oluþtur,, baþta hepsi arka plan formatýnda görünsün
            buton_dizi(i).Image = arka_plan.Image
            'görünür yap
            buton_dizi(i).Visible = True
        Next

        YER1.Visible = True
        YER2.Visible = True
        YER3.Visible = True
        button10.Enabled = True
        button9.Enabled = False
    End Sub

    'puan functionu sayesinde gönderilen kaðýdýn puanlanmasý yapýlýp çaðrýldýðý yere geri gönderiliyor
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
        'oyuncu adlarýn gösterileceði labellara isimleri yaz
        label2.Text = toolStripTextBox1.Text
        label3.Text = toolStripTextBox2.Text
        label4.Text = toolStripTextBox3.Text
        label5.Text = toolStripTextBox4.Text

        label6.Text = toolStripTextBox1.Text
        label7.Text = toolStripTextBox2.Text
        label8.Text = toolStripTextBox3.Text
        label9.Text = toolStripTextBox4.Text

        oyunu_baþlat()

        'butonlarýn textinde yazý gözükmemesi için yazýyý küçülttüm
        Dim i As Integer
        For i = 0 To 15
            buton_dizi(i).Font = New Font("Microsoft Sans Serif", 1, FontStyle.Regular)
            buton_dizi(i).ForeColor = Color.White
        Next
    End Sub

    Private Sub button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button10.Click
        'kaðýtlar karýþtýrýlýyor ve oyuncu kaðýtlarý görünüryapýlýyor
        x = 0
        kartlarý_karýstýr()
        button10.Enabled = False
        button9.Enabled = True
        Dim i As Integer
        For i = 0 To 15
            buton_dizi(i).Visible = True
        Next
    End Sub

    Private Sub button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button9.Click
        'kaðýtlar daðýtýlýyor
        button10.Enabled = False
        dagýt()
    End Sub

    Private Sub b1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles b1.Click, b2.Click, b3.Click, b4.Click
        'bizim attýðýmýz kaðýtlar için
        tut = 0 'diðer oyuncularýn oynamasý için tanýmlandý yukarýda açýklamasý var
        'buton 1,2,3,4 i buraya baðla
        Dim i As Integer
        Dim yeni As Button
        For i = 0 To 3
            'buton 1,2,3,4 mi diye bakýlýyor
            If (sender Is buton_dizi(i)) Then
                'eðer yerdekiyle tutmuyosa yere onu koy ve visible ýný false yap
                yeni = buton_dizi(i)
            End If
        Next

        Dim bosluk As Integer = yeni.Text.IndexOf(" ", 0)  'boþluðun kaçýncý karakter olduðuna bakýyorum
        Dim tipi As String = yeni.Text.Substring(0, bosluk)
        Dim kagýt_numarasýný_al As String = "" 'atýlan kaðýdýn ne olduðuna bakýcam



        'kupa mý sinek mi olduðu ile ilgilenmiyorum
        'sayýsý önemli o yüzden boþluktan sonrasýný keserek alýcam
        kagýt_numarasýný_al = yeni.Text.Substring(bosluk + 1, yeni.Text.Length - bosluk - 1)

        Dim deger As Integer = puan(kagýt_numarasýný_al, tipi)
        puantut.Add(deger)

        Dim bosluk1 As Integer = yer.Text.IndexOf(" ", 0)
        Dim kagýt_numarasýný_al1 As String
        kagýt_numarasýný_al1 = yer.Text.Substring(bosluk1 + 1, yer.Text.Length - bosluk1 - 1)

        If ((kagýt_numarasýný_al = kagýt_numarasýný_al1) And (pistimi <> "")) Then
            MessageBox.Show("pisti oldu")
            listBox1.Items.Add(10)
        End If
        pisti = "dene"

        If ((kagýt_numarasýný_al = kagýt_numarasýný_al1) Or (kagýt_numarasýný_al = "vale")) Then

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
        'this.Text = kagýt_numarasýný_al 

        yer.Text = yeni.Text


        yeni.Visible = False
        'oynadýktan sonra diðerlerine oynat
        tut = 4

        Me.Refresh()
        System.Threading.Thread.Sleep(1500)
        oynat()
    End Sub

    'menüden isimler deðiþtirilir deðiþtirmez labellara aktar..
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
        oyunu_baþlat()
    End Sub
End Class
