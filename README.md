# PharmacyCompany
Каждой из этих команд будет соответствовать соответствующая операция: --addproduct|--addpharmacy|--addwarehouse|--addconsignment|--removeproduct|--removepharmacy|--removewarehouse|--removeconsignment
Флаги для товара: --title
Флаги для апетек: --title, --address, --phone
Флаги для складов: --title, --pharmacyId
Флаги для партий: --warehouseId, --productId, --quantity
Для удаления используется только флаг --id
Есть команда --list, для отображения всех товаров по аптеке. Используется с флагом --id

Примеры:
PharmacyCompany.exe --addproduct --title test
PharmacyCompany.exe --list --id 1
