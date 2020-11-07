export class CorrectDate {
  static correct(d: Date): Date {
    if (d == null)
      return null;

    let dd = new Date(d);
    let offest = dd.getTimezoneOffset();
    dd.setMinutes(dd.getMinutes() + offest);

    return dd;
  }
}
