# Coop Simulation

Kümeste t=0 anında 1 erkek ve 1 dişi tavşan var. İstenilen t zaman dilimi sonrasında kümesteki tavşanların yaş ve cinsiyet dağılımlarının ekran çıktısı verilecektir.
Prametrik t değişkeni json dosyasından okunmaktadır. (Proje derlendiği zaman LifeCycleMonth.json 'sı derlenen klasörün içerisine alınmalı. Yoksa Default t verilecektir.) 

#Değişkenler:

   - Var olan kümes hayvan ortalama yaşam süreleri.
   - Dişi kümes hayvanlarının bir seferde doğurabileceği yavru adedi. (Random değer verilmektedir)
   - Doğumların dişi erkek yüzdesi. (En yakın tam sayıya yuvarlanacak.)
   - Doğum öncesi, doğum süreci ve doğrum sonraki süreçler.
   - Dişi kümes hayvanlarının doğurganlıklarını yitirme süreleri

**(Tüm süreler ay cinsinden)

#Özet;   
Program json dosyasındaki ay bilgisi üzerinden, kümes durumunu simule edecek ve  kümesteki hayvan popülasyonunu ekrana yansıtacak.  Örnek çıktı;
   
   
   > - 0 aylık 21 dişi 63 erkek
   > - 3 aylık 13  dişi 38  erkek...
