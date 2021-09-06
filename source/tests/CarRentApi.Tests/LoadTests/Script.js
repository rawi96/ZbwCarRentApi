import http from 'k6/http';
import { check, sleep } from 'k6';
import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";
import { textSummary } from "https://jslib.k6.io/k6-summary/0.0.1/index.js";

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

export function handleSummary(data) {
    return {
        "testResults/load-tests.html": htmlReport(data),
        stdout: textSummary(data, { indent: " ", enableColors: true }),
    };
}