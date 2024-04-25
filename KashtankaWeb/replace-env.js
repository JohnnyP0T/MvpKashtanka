const fs = require('fs');
const path = './src/environments/environment.ts';

// Чтение переменной окружения
const apiUrl = process.env.API_URL;

let content = fs.readFileSync(path, { encoding: 'utf8' });
content = content.replace(/\$\{API_URL\}/g, apiUrl);

fs.writeFileSync(path, content);
