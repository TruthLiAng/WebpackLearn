import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'test',
    templateUrl: './test.component.html'
})
export class TestComponent {
    public test: number;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/SampleData/test').subscribe(result => {
            this.test = result.json() as number;
        }, error => console.error(error));
    }
}
