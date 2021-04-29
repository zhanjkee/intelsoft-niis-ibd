# intelsoft-niis-ibd


# Описание сервиса

Сервис содержит 2 модуля:
1)	Отправляет сообщение, которое содержит информацию о договорах и связанных объектах (согласно схеме ТЗ) в ИБД через ШЭП. Полученный ответ от ШЭП сохраняет в таблицу niis_ibd.dbo.messages.
2)	Принимает ответ от ИБД через ШЭП и сохраняет в таблицу niis_ibd.dbo.ibdresponses. Ответ содержит информацию о статусе обработке сообщения.


# Описание сборок


**Intelsoft.Niis.Ibd.Configuration** – Содержит базовые конфигурации, необходимые для всех сборок.

**Intelsoft.Niis.Ibd.ContractSenderService.Autofac** – IoC контейнер. Содержит регистрацию сервисов отправки сообщении в ШЭП.

**Intelsoft.Niis.Ibd.ContractSenderService.Configuration** – Содержит конфигурации необходимые для отправки сообщения. Например, адрес ШЭП-а, логин, пароль, название сервиса и т.д.

**Intelsoft.Niis.Ibd.ContractSenderService.Core** – Содержит реализацию отправки сообщения в ИБД через ШЭП.

**Intelsoft.Niis.Ibd.ContractSenderService.Domain** – Содержит доменные модели, используемые в сборках **Intelsoft.Niis.Ibd.ContractSenderService.***.

**Intelsoft.Niis.Ibd.Data.Autofac** – IoC контейнер. Содержит регистрацию классов уровня данных.

**Intelsoft.Niis.Ibd.Data.Configuration** – Содержит конфигурации, необходимые для уровня данных. Например, строка подключения к БД.

**Intelsoft.Niis.Ibd.Data.Interfaces**– Содержит абстракцию доступа к данным. Например, репозиторий.

**Intelsoft.Niis.Ibd.Data** – Содержит реализацию доступа к данным. 

**Intelsoft.Niis.Ibd.Entities** – Содержит сущности. Например, MessageEntity, IbdResponseEntity, ContractRequestEntity и т.д.

**Intelsoft.Niis.Ibd.Infrastructure.Autofac** - IoC контейнер. Содержит регистрацию сервисов инфраструктуры.

**Intelsoft.Niis.Ibd.Infrastructure.Serilog.Configuration** – Содержит конфигурации для логгера. Например, путь  лог файлам, размер файла и т.д.

**Intelsoft.Niis.Ibd.Infrastructure** - Содержит классы для доступа к внешним ресурсам, таким как SoapExecutor, Serilog Configuration Builder.

**Intelsoft.Niis.Ibd.ReceiveStatusService.Autofac** – IoC контейнер. Содержит регистрацию сервиса приема ответа от ИБД
**Intelsoft.Niis.Ibd.ReceiveStatusService.Configuration** – Содержит конфигурации необходимые для сервиса, который принимает ответ от ИБД. Например, веб-адрес.

**Intelsoft.Niis.Ibd.ReceiveStatusService.Contract** – Содержит абстракцию сервиса, который принимает ответ от ИБД.

**Intelsoft.Niis.Ibd.ReceiveStatusService.Implementation** – Содержит реализацию сервиса, который принимает ответ от ИБД. Реализует интерфейсы из **Intelsoft.Niis.Ibd.ReceiveStatusService.Contract**

**Intelsoft.Niis.Ibd.Selfhost** – Корень композиции.

**Intelsoft.Niis.Ibd.Shared** – Разделяемая сборка, содержит общие классы,  методы расширения. Напимер, XML-сериализация.

**Intelsoft.Niis.Ibd.Validation** - Содержит пользовательские атрибуты валидации.



# Установка сервиса

Корень композиции Intelsoft.Niis.Ibd.Selfhost поддерживает команды.
Основные команды install, uninstall, start, stop. Например, Intelsoft.Niis.Ibd.Selfhost install.

Подробности о поддерживаемых командах можно узнать тут http://docs.topshelf-project.com/en/latest/overview/commandline.html
