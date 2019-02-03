import { Component, OnInit } from '@angular/core';
import {Twitter} from '../Model/Twitter';
import {TwitterservicesService} from '../services/twitterservices.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-most-relevants',
  templateUrl: './most-relevants.component.html',
  styleUrls: ['./most-relevants.component.styl']
})
export class MostRelevantsComponent implements OnInit {

  twitters: Twitter[];

  constructor(private twitterSerivce: TwitterservicesService, private _router: Router) {}

  ngOnInit() {
    console.log('init log');
    this.twitterSerivce.obterMostRelevants()
      .subscribe((data: Twitter[]) => {
        this.twitters = data;
      });
  }

}
