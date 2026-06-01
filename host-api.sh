# Скрипт для создания публичного URL к локальному API через Cloudflare Tunnel

API_PORT=${1:-5003}

echo "Запуск туннеля к http://localhost:$API_PORT ..."
echo "Подождите, публичный URL появится ниже (строка 'Your quick Tunnel' или 'https://...')"
echo ""

cloudflared tunnel --url "http://localhost:$API_PORT"
