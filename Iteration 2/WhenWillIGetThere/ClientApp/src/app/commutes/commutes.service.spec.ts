import { TestBed } from '@angular/core/testing';

import { CommutesService } from './commutes.service';

describe('CommutesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CommutesService = TestBed.get(CommutesService);
    expect(service).toBeTruthy();
  });
});
