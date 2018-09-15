import { TestBed } from '@angular/core/testing';

import { SubmitCodeService } from './submit-code.service';

describe('SubmitCodeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SubmitCodeService = TestBed.get(SubmitCodeService);
    expect(service).toBeTruthy();
  });
});
