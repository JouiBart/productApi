import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    stages: [
        { duration: '10s', target: 100 }, 
        { duration: '10s', target: 200 },  
        { duration: '00s', target: 0 },  
    ],
};

export default function () {
    let res = http.get('https://localhost:7117/api/product/GetProduct?id=1');
    check(res, {
        'status is 200': (r) => r.status === 200,
    });
    sleep(1);
/*
    let res = http.get('https://localhost:7117/api/product/GetAllProducts');
    check(res, {
        'status is 200': (r) => r.status === 200,
    });
    sleep(1);*/
}