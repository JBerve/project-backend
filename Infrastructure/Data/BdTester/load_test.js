import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        { duration: '30s', target: 100 }, // 30 segundos a 100 usuarios concurrentes
        { duration: '1m', target: 100 },  // 1 minuto a 100 usuarios concurrentes
        { duration: '30s', target: 0 },   // 30 segundos de descenso a 0 usuarios concurrentes
    ],
};

export default function () {
    let res = http.get('http://localhost:5000/api/users'); // Ajusta la URL según tu API
    check(res, {
        'is status 200': (r) => r.status === 200,
    });
    sleep(1);
}