import { TestBed } from '@angular/core/testing';

import { TwitterservicesService } from './twitterservices.service';

describe('TwitterservicesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TwitterservicesService = TestBed.get(TwitterservicesService);
    expect(service).toBeTruthy();
  });
});
