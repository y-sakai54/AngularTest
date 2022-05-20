import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html'
})
export class RankingComponent {
  private http: HttpClient;
  private baseUrl?: string;
  public rankings: Ranking[] = [];
  public flg1: boolean;
  public isWarning: boolean = true;
  public textType: TextType = TextType.NORMAL;
  TextType = TextType;
  reactiveForm: FormGroup;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private fb: FormBuilder) {
    this.http = http;
    this.baseUrl = baseUrl;

    this.flg1 = false;

    this.http.get<Ranking[]>(this.baseUrl + 'ranking').subscribe(result => {
      this.rankings = result;
    }, error => console.error(error));

    // フォーム関連
    this.reactiveForm = fb.group({
      name: ["", [Validators.required]],
    });
  }

  reactiveSubmit() {
    if (!this.reactiveForm.invalid) {
      var name = this.reactiveForm.controls["name"].value;
      // 追加するテストデータ
      var data = { Id: 0, Rank: 99, Name: name, Score: 9999 };

      this.http.post<Ranking[]>(this.baseUrl + 'ranking', data).subscribe(result => {
        this.rankings = result;
      }, error => console.error(error));
    }
  }
}

enum TextType {
  NORMAL = 'normal', WARNING = 'warning', DANGER = 'danger'
}


interface Ranking {
  id: number;
  rank: number;
  name: string;
  score: number;
}
