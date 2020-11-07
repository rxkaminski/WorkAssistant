import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';


@Pipe({
  name: 'date'
})
export class DefaultDatePipe extends DatePipe implements PipeTransform {
  customDateFormats: any;
  constructor() {
    super('en-US');
  

    this.customDateFormats = {
      withHms: 'yyyy-MM-dd HH:mm:ss',
      withHm: 'yyyy-MM-dd HH:mm',
      default: 'yyyy-MM-dd'
    };
  }

  transform(value: any, args?: any): any {
    switch (args) {
      case 'withHms':
        return super.transform(value, this.customDateFormats.withHms);
      case 'withHm':
        return super.transform(value, this.customDateFormats.withHm);

      default:
        return super.transform(value, this.customDateFormats.default);
    }
  }
}

