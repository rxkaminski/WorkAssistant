export class ApplicationUserShort implements IApplicationUserShort {
  Id: number;
  FirstName: string;
  LastName: string;

  constructor(applicationUserShort: IApplicationUserShort) {
    this.Id = applicationUserShort.Id;
    this.FirstName = applicationUserShort.FirstName;
    this.LastName = applicationUserShort.LastName;
  }


  isEqual(other: ApplicationUserShort): boolean {
    return this.Id == other.Id;
  }

  public toString(): string {
    return this.FirstName + " " + this.LastName;
  }
}
