export class IdViewValue {
  Id: number;
  ViewValue: string;

  constructor(props: { id: number; viewValue: string; }) {
    this.Id = props.id;
    this.ViewValue = props.viewValue;
  }

  isEqual(other: IdViewValue): boolean {
    return this.Id == other.Id;//&& this.viewValue == hourValue.viewValue;
  }

  public toString(): string {
    return this.ViewValue;
  }
}
