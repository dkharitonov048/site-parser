# site-parser
---
В данном приложении представлен парсер веб-сайтов, который обходит страницы заданного сайта и собирает ссылки, имеющиеся в нем.
---
Сбор ссылок осуществляется по-разному, в зависимости от выбора определенной, заранее заданной, стратегии поиска. 
---
Расширяемость реализована на основе паттерна Strategy. Для добавления новой стратегии необходимо создать новый класс-наследник базового класса SearchStrategy, и реализовать его методы, с учетом требуемых новых условностей поиска, а также добавить созданную стратегию в фабрику порождения классов-стратегий, задав ей уникальное название. Подразумевается, что инстанс фабрики будет единственным для всего приложения, поэтому он содержит в себе коллекцию экземпляров каждой стратегии и при обращении отдает уже созданный экземпляр.
---
Обход и анализ страниц сайта выполняется рекурсивно в несколько потоков. Ссылки на внешние сайты добавляются в результирующую коллекцию, однако их анализ не производится. 
--- 
На выходе образуется коллекция уникальных ссылок.
---

Чтобы оттенить работу приложения внутри класса Parser в методе Parse на консоль выводится отобранная ссылка, которая попадет в результирующую коллекцию. При необходимости данный вывод на экран можно убрать, по завершению работы партера вся коллекция будет отображена повторно, но уже в отсортированном виде.
---
