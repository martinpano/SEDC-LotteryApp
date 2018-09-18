import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { IUserCodeAward } from './winners-list.model';
import { WinnersListService } from './winners-list.service';

@Component({
  selector: 'app-winners-list',
  templateUrl: './winners-list.component.html',
  styleUrls: ['./winners-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class WinnersListComponent implements OnInit {

  public winners: Array<IUserCodeAward>;


  constructor(private winnersListService: WinnersListService) {
    this.winners = [];
  }

  ngOnInit() {
    this.winnersListService.getAllWinners().subscribe((result) => {
      this.winners = result;
    }, (error) => {
      console.log(error);
    });
  }

}
