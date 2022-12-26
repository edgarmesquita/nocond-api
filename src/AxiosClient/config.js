module.exports = {
    files: './src/index.ts',
    from: [
        /for \(let attr in item\)(\s)*if \(item\.hasOwnProperty\(attr\)\) \{(\s)*url_ \+\= "filterBy\[" \+ index \+ "\]\." \+ attr \+ "\=" \+ encodeURIComponent\("" \+ \(<any>item\)\[attr\]\) \+ "&";(\s)*\}/gm,
        /for \(let attr in item\)(\s)*if \(item\.hasOwnProperty\(attr\)\) \{(\s)*url_ \+\= "orderBy\[" \+ index \+ "\]\." \+ attr \+ "\=" \+ encodeURIComponent\("" \+ \(<any>item\)\[attr\]\) \+ "&";(\s)*\}/gm,
        /(export abstract class IFiltering implements IIFiltering \{\s*columnName\?\: string \| undefined;\s*operator\?\: FilterOperator;\s*stringValue\?\: string \| undefined;\s*constructor.*\s*.*\s*.*\s*.*\s*.*\s*\}\s*\}\s*\}\s*)(init)/gm,
        /(export abstract class ISorting implements IISorting \{\s*columnName\?\: string \| undefined;\s*sortDirection\?\: SortDirection;\s*constructor.*\s*.*\s*.*\s*.*\s*.*\s*\}\s*\}\s*\}\s*)(init)/gm,
        /IFiltering/gm,
        /ISorting/gm
    ],
    to: [
        'url_ += "filterBy=" + encodeURIComponent(item.toString()) + "&";',
        'url_ += "orderBy=" + encodeURIComponent(item.toString()) + "&";',
        '$1getOperatorName() : string {\n\
            const op = this.operator || FilterOperator.Equal;\n\
            switch(op)\n\
            {\n\
                case FilterOperator.Equal: return "eq";\n\
                case FilterOperator.NotEqual: return "neq";\n\
                case FilterOperator.Contains: return "contains";\n\
                case FilterOperator.StartsWith: return "sw";\n\
                case FilterOperator.EndsWith: return "ew";\n\
                case FilterOperator.GreaterThan: return "gt";\n\
                case FilterOperator.GreaterThanOrEqual: return "gte";\n\
                case FilterOperator.LessThan: return "lt";\n\
                case FilterOperator.LessThanOrEqual: return "lte";\n\
            }\n\
        }\n    public toString = () : string => { return `\${this.columnName}:\${this.getOperatorName()}(\${this.stringValue})`;}\n    init',
        '$1\n    public toString = () : string => { return `\${this.columnName}:\${this.sortDirection == SortDirection.Ascending ? "asc" : "desc"}`;}\n    init',
        'Filtering',
        'Sorting'
    ],
};