ContactApp

### Docker

- `docker build -t full-contact . --no-cache` создания Docker-образа,
`--no-cache` не использовать кэш от предыдущих сборок

- `docker run -d -p 8002:5000 --name app-contact-1 full-contact` создает и запускает новый контейнер
в фоновом режиме на основе Docker-образа "full-contact", связывает порт 8001 хоста с портом
5000 контейнера и присваивает контейнеру имя "app-contact-1".

- `docker tag full-contact EgorS94/full-contact:latest` создает новый тег для существующего Docker-образа

- `docker push EgorS94/full-contact:latest` отправляет локальный Docker-образ в удаленный репозиторий