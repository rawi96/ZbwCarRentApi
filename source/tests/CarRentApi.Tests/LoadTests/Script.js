import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    stages: [
        { duration: '6s', target: 20 },
        { duration: '12', target: 50 },
        { duration: '12s', target: 100 },
        { duration: '6s', target: 0 },
    ],
};

export default function () {
    let res = http.get('https://httpbin.org/');
    check(res, { 'status was 200': (r) => r.status == 200 });
    sleep(1);
}