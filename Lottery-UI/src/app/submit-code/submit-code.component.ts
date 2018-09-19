import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { SubmitCodeService } from './submit-code.service';
import { IUserCode, ICode } from '../winners-list/winners-list.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-submit-code',
  templateUrl: './submit-code.component.html',
  styleUrls: ['./submit-code.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class SubmitCodeComponent implements OnInit {

  userCode: IUserCode = {} as IUserCode;

  constructor(private submitCodeService: SubmitCodeService, private toastrService: ToastrService, private router: Router) {
    this.userCode.code = {} as ICode;
  }

  ngOnInit() {
  }

  submit() {

    this.submitCodeService.submitCode(this.userCode).subscribe((result) => {
      if (!!result) {
        this.toastrService.success("Dear user you got" + " " + result.AwardName, "Winner!");
      } else {
        this.toastrService.info("Better luck next time :(")
      }
      this.router.navigate(['winners']);
    }, (error) => {
      this.toastrService.error(error.error.ExceptionMessage, "Error!");
      this.router.navigate(['winners']);
    });
  }
}
