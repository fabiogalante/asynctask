import { Component, OnInit } from '@angular/core';
import {Twitter} from '../Model/Twitter';
import {TwitterservicesService} from '../services/twitterservices.service';
import {Router} from '@angular/router';
import {MostMentionsName} from '../Model/MostMentions';

@Component({
  selector: 'app-most-mentions',
  templateUrl: './most-mentions.component.html',
  styleUrls: ['./most-mentions.component.styl']
})
export class MostMentionsComponent implements OnInit {

  twitters: MostMentionsName[];

  constructor(private twitterSerivce: TwitterservicesService, private _router: Router) {}

  ngOnInit() {

    this.twitterSerivce.obterMostMentions()
      .subscribe((data: MostMentionsName[]) => {
        this.twitters = data;
        console.log(this.twitters);
      });


  }

}
