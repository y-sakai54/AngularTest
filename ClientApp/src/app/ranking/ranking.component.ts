import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-ranking',
  templateUrl: './ranking.component.html'
})
export class RankingComponent {
  public rankings: Ranking[] = [];
  public flg1: boolean;
  public isWarning: boolean = true;
  public textType: TextType = TextType.NORMAL;
  TextType = TextType;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Ranking[]>(baseUrl + 'ranking').subscribe(result => {
      this.rankings = result;
    }, error => console.error(error));
    this.flg1 = false;
  }
}

enum TextType {
  NORMAL = 'normal', WARNING = 'warning', DANGER = 'danger'
}


interface Ranking {
  rank: number;
  name: string;
}
