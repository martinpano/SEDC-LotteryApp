import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitCodeComponent } from './submit-code.component';

describe('SubmitCodeComponent', () => {
  let component: SubmitCodeComponent;
  let fixture: ComponentFixture<SubmitCodeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubmitCodeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubmitCodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
