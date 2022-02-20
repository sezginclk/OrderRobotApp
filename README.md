# OrderRobotApp
Siparişlerin Robot Sistemine Aktarımını Sağlayan Servis


Sistemde .Net Core ile yapılmıştır.

2 ayrı servis kullanılmıştır. Bu servislerden biri task oluşturma diğeri task ın işlem durumunu(çalışılıyor, tamamlandı, hata aldı) güncellemek için kullanılır.

Proje içerisinde SQL lite kullanılmıştır. herhangi bir nosql veya sql sistemi dahil edilebilir.Migration yapısı oluşturulmuştur.

2 serviste aynı veri tabanı kullanacak şekilde katmanlı mimari ile yapılmıştır.

JWT token işlemi dahil edilmiştir. Kullanıcı adı şifre verilerek Authenticate işlemi yapılıp token alınmalı daha sonra API uçları kullanılmalıdır.

2 servisin birbiri ile haberleşebilmesi ,kuyruk sistemi oluşturulması için Cap sistemi üzerinden RabbitMQ kullanılmıştır.ayağa kaldırılabilmesi için

ise 'docker-compose up -d' kodu kullanılmalıdır.


api/Task/Create   ---> Robotun task oluşturması için bu uç kullanılır. (lokasyon bilgisi ve adet verilmeli)

api/Task/Update   ---> Daha önce eklenmiş task ile ilgili güncelleme işlemi yapılabilir.

api/Task/Delete   ---> Daha önce eklenmiş task silinebilir.

