import { AxiosInstance, AxiosResponse, CancelToken } from 'axios';
import * as moment from 'moment';
export declare class OwnerClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a document
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<Owner>;
    protected processGet(response: AxiosResponse): Promise<Owner>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: OwnerRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfOwner>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfOwner>;
    /**
     * Creates a document.
     * @param dto The dto.
     */
    post(dto: OwnerRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class OwnerTypeClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a document
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<OwnerType>;
    protected processGet(response: AxiosResponse): Promise<OwnerType>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: OwnerTypeRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfOwnerType>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfOwnerType>;
    /**
     * Creates a document.
     * @param dto The dto.
     */
    post(dto: OwnerTypeRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class UnitClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a document
     */
    get(unitGroupId: string, id: string, cancelToken?: CancelToken | undefined): Promise<Unit>;
    protected processGet(response: AxiosResponse): Promise<Unit>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param request The request.
     */
    put(unitGroupId: string, id: string, request: UnitRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(unitGroupId: string, id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(unitGroupId: string, filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfUnit>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfUnit>;
    /**
     * Creates a document.
     * @param request The request.
     */
    post(unitGroupId: string, request: UnitRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
    /**
     * Creates many units by range.
     * @param request The request.
     */
    post2(unitGroupId: string, request: UnitRangeRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost2(response: AxiosResponse): Promise<number>;
}
export declare class UnitGroupClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a unit group.
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<UnitGroup>;
    protected processGet(response: AxiosResponse): Promise<UnitGroup>;
    /**
     * Updates a unit group by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: UnitGroupRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a unit group by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets unit groups by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfUnitGroup>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfUnitGroup>;
    /**
     * Creates a unit group.
     * @param dto The dto.
     */
    post(dto: UnitGroupRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class UnitTypeClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a document
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<UnitType>;
    protected processGet(response: AxiosResponse): Promise<UnitType>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: UnitTypeRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfUnitType>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfUnitType>;
    /**
     * Creates a document.
     * @param dto The dto.
     */
    post(dto: UnitTypeRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class MeetingSettingsClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets the current meeting settings
     */
    get(cancelToken?: CancelToken | undefined): Promise<MeetingSettings>;
    protected processGet(response: AxiosResponse): Promise<MeetingSettings>;
    /**
     * Updates the meeting settings
     */
    post(request: MeetingSettingsRequest, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processPost(response: AxiosResponse): Promise<void>;
}
export declare class PersonClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a person.
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<Person>;
    protected processGet(response: AxiosResponse): Promise<Person>;
    /**
     * Updates a person by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: PersonRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a person by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets people by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfPerson>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfPerson>;
    /**
     * Creates a person.
     * @param dto The dto.
     */
    post(dto: PersonRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class PersonUnitClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a unit by person
     */
    get(personId: string, id: string, cancelToken?: CancelToken | undefined): Promise<Unit>;
    protected processGet(response: AxiosResponse): Promise<Unit>;
    /**
     * Updates a owner by identifier.
     * @param id The id.
     * @param request The request.
     */
    put(personId: string, id: string, request: PersonUnitRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a owner by identifier.
     * @param id The id.
     */
    delete(personId: string, id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets units by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(personId: string, filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfUnit>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfUnit>;
    /**
     * Creates a owner.
     * @param request The request.
     */
    post(personId: string, request: PersonUnitRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class DocumentClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a document
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<Document>;
    protected processGet(response: AxiosResponse): Promise<Document>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: DocumentRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfDocument>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfDocument>;
    /**
     * Creates a document.
     * @param dto The dto.
     */
    post(dto: DocumentRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class MeetingClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a meeting
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<Meeting>;
    protected processGet(response: AxiosResponse): Promise<Meeting>;
    /**
     * Updates a meeting by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: MeetingRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a meeting by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets mettings by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfMeeting>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfMeeting>;
    /**
     * Creates a meeting.
     * @param dto The dto.
     */
    post(dto: MeetingRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
    /**
     * Invite.
     * @param id The id.
     */
    invite(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processInvite(response: AxiosResponse): Promise<void>;
}
export declare class MeetingTypeClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a meeting type.
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<MeetingType>;
    protected processGet(response: AxiosResponse): Promise<MeetingType>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: MeetingTypeRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfMeetingType>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfMeetingType>;
    /**
     * Creates a document.
     * @param dto The dto.
     */
    post(dto: MeetingTypeRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class MeetingUnitClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a document
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<MeetingUnit>;
    protected processGet(response: AxiosResponse): Promise<MeetingUnit>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: MeetingUnitRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfMeetingUnit>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfMeetingUnit>;
    /**
     * Creates a document.
     * @param dto The dto.
     */
    post(dto: MeetingUnitRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class VotingSessionClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a document
     */
    get(meetingId: string, id: string, cancelToken?: CancelToken | undefined): Promise<VotingSession>;
    protected processGet(response: AxiosResponse): Promise<VotingSession>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(meetingId: string, id: string, dto: VotingSessionRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(meetingId: string, id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(meetingId: string, filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfVotingSession>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfVotingSession>;
    /**
     * Creates a document.
     * @param dto The dto.
     */
    post(meetingId: string, dto: VotingSessionRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class VotingTopicClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a document
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<VotingTopic>;
    protected processGet(response: AxiosResponse): Promise<VotingTopic>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: VotingTopicRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfVotingTopic>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfVotingTopic>;
    /**
     * Creates a document.
     * @param dto The dto.
     */
    post(dto: VotingTopicRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class VotingTopicOptionClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a document
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<VotingTopicOption>;
    protected processGet(response: AxiosResponse): Promise<VotingTopicOption>;
    /**
     * Updates a document by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: VotingTopicOptionRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a document by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets documents by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfVotingTopicOption>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfVotingTopicOption>;
    /**
     * Creates a document.
     * @param dto The dto.
     */
    post(dto: VotingTopicOptionRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class EmailTemplateClient {
    private instance;
    private baseUrl;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined;
    constructor(baseUrl?: string, instance?: AxiosInstance);
    /**
     * Gets a email template
     */
    get(id: string, cancelToken?: CancelToken | undefined): Promise<EmailTemplate>;
    protected processGet(response: AxiosResponse): Promise<EmailTemplate>;
    /**
     * Updates a email template by identifier.
     * @param id The id.
     * @param dto The dto.
     */
    put(id: string, dto: EmailTemplateRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPut(response: AxiosResponse): Promise<number>;
    /**
     * Deletes a email template by identifier.
     * @param id The id.
     */
    delete(id: string, cancelToken?: CancelToken | undefined): Promise<void>;
    protected processDelete(response: AxiosResponse): Promise<void>;
    /**
     * Gets email templates by criteria.
     * @param filterBy The filter by.
     * @param orderBy The order by.
     * @param pageIndex (optional) The page index.
     * @param pageSize (optional) The page size.
     */
    getAll(filterBy: Filtering[] | null, orderBy: Sorting[] | null, pageIndex: number | undefined, pageSize: number | undefined, cancelToken?: CancelToken | undefined): Promise<PagedListResultOfEmailTemplate>;
    protected processGetAll(response: AxiosResponse): Promise<PagedListResultOfEmailTemplate>;
    /**
     * Creates a email template.
     * @param dto The dto.
     */
    post(dto: EmailTemplateRequest, cancelToken?: CancelToken | undefined): Promise<number>;
    protected processPost(response: AxiosResponse): Promise<number>;
}
export declare class ProblemDetails implements IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
    extensions?: {
        [key: string]: any;
    } | undefined;
    constructor(data?: IProblemDetails);
    init(_data?: any): void;
    static fromJS(data: any): ProblemDetails;
    toJSON(data?: any): any;
}
export interface IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
    extensions?: {
        [key: string]: any;
    } | undefined;
}
export declare class Owner implements IOwner {
    id?: string;
    person?: Person | undefined;
    unit?: Unit | undefined;
    type?: OwnerType | undefined;
    constructor(data?: IOwner);
    init(_data?: any): void;
    static fromJS(data: any): Owner;
    toJSON(data?: any): any;
}
export interface IOwner {
    id?: string;
    person?: Person | undefined;
    unit?: Unit | undefined;
    type?: OwnerType | undefined;
}
export declare abstract class AuditMetadata implements IAuditMetadata {
    createdById?: string | undefined;
    createdOn?: moment.Moment;
    lastUpdatedById?: string | undefined;
    lastUpdatedOn?: moment.Moment | undefined;
    constructor(data?: IAuditMetadata);
    init(_data?: any): void;
    static fromJS(data: any): AuditMetadata;
    toJSON(data?: any): any;
}
export interface IAuditMetadata {
    createdById?: string | undefined;
    createdOn?: moment.Moment;
    lastUpdatedById?: string | undefined;
    lastUpdatedOn?: moment.Moment | undefined;
}
export declare class Person extends AuditMetadata implements IPerson {
    id?: string;
    address?: Address | undefined;
    name?: string | undefined;
    email?: string | undefined;
    phoneNumber?: string | undefined;
    mobilePhoneNumber?: string | undefined;
    nickname?: string | undefined;
    taxNumber?: string | undefined;
    idNumber?: string | undefined;
    type?: PersonType;
    constructor(data?: IPerson);
    init(_data?: any): void;
    static fromJS(data: any): Person;
    toJSON(data?: any): any;
}
export interface IPerson extends IAuditMetadata {
    id?: string;
    address?: Address | undefined;
    name?: string | undefined;
    email?: string | undefined;
    phoneNumber?: string | undefined;
    mobilePhoneNumber?: string | undefined;
    nickname?: string | undefined;
    taxNumber?: string | undefined;
    idNumber?: string | undefined;
    type?: PersonType;
}
export declare class Address extends AuditMetadata implements IAddress {
    id?: string;
    address1?: string | undefined;
    address2?: string | undefined;
    number?: string | undefined;
    city?: string | undefined;
    state?: string | undefined;
    postalCode?: string | undefined;
    constructor(data?: IAddress);
    init(_data?: any): void;
    static fromJS(data: any): Address;
    toJSON(data?: any): any;
}
export interface IAddress extends IAuditMetadata {
    id?: string;
    address1?: string | undefined;
    address2?: string | undefined;
    number?: string | undefined;
    city?: string | undefined;
    state?: string | undefined;
    postalCode?: string | undefined;
}
export declare enum PersonType {
    Fisical = 0,
    Legal = 1
}
export declare class Unit implements IUnit {
    id?: string;
    floor?: number;
    floorType?: FloorType;
    block?: string | undefined;
    blockDescription?: string | undefined;
    side?: string | undefined;
    code?: string | undefined;
    codePrefix?: string | undefined;
    codeSuffix?: string | undefined;
    type?: UnitType | undefined;
    unitGroup?: UnitGroup | undefined;
    constructor(data?: IUnit);
    init(_data?: any): void;
    static fromJS(data: any): Unit;
    toJSON(data?: any): any;
}
export interface IUnit {
    id?: string;
    floor?: number;
    floorType?: FloorType;
    block?: string | undefined;
    blockDescription?: string | undefined;
    side?: string | undefined;
    code?: string | undefined;
    codePrefix?: string | undefined;
    codeSuffix?: string | undefined;
    type?: UnitType | undefined;
    unitGroup?: UnitGroup | undefined;
}
export declare enum FloorType {
    Underground = 0,
    GroundFloor = 1,
    Floor = 2,
    Roof = 3
}
export declare class UnitType implements IUnitType {
    id?: string;
    name?: string | undefined;
    description?: string | undefined;
    createdOn?: moment.Moment;
    constructor(data?: IUnitType);
    init(_data?: any): void;
    static fromJS(data: any): UnitType;
    toJSON(data?: any): any;
}
export interface IUnitType {
    id?: string;
    name?: string | undefined;
    description?: string | undefined;
    createdOn?: moment.Moment;
}
export declare class UnitGroup implements IUnitGroup {
    id?: string;
    name?: string | undefined;
    createdOn?: moment.Moment;
    constructor(data?: IUnitGroup);
    init(_data?: any): void;
    static fromJS(data: any): UnitGroup;
    toJSON(data?: any): any;
}
export interface IUnitGroup {
    id?: string;
    name?: string | undefined;
    createdOn?: moment.Moment;
}
export declare class OwnerType implements IOwnerType {
    id?: string;
    name?: string | undefined;
    description?: string | undefined;
    constructor(data?: IOwnerType);
    init(_data?: any): void;
    static fromJS(data: any): OwnerType;
    toJSON(data?: any): any;
}
export interface IOwnerType {
    id?: string;
    name?: string | undefined;
    description?: string | undefined;
}
export declare class PagedListResultOfOwner implements IPagedListResultOfOwner {
    items?: Owner[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfOwner);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfOwner;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfOwner {
    items?: Owner[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare abstract class Filtering implements IFiltering {
    columnName?: string | undefined;
    operator?: FilterOperator;
    stringValue?: string | undefined;
    constructor(data?: IFiltering);
    getOperatorName(): string;
    toString: () => string;
    init(_data?: any): void;
    static fromJS(data: any): Filtering;
    toJSON(data?: any): any;
}
export interface IFiltering {
    columnName?: string | undefined;
    operator?: FilterOperator;
    stringValue?: string | undefined;
}
export declare enum FilterOperator {
    Equal = 0,
    NotEqual = 1,
    Contains = 2,
    StartsWith = 3,
    EndsWith = 4,
    GreaterThan = 5,
    GreaterThanOrEqual = 6,
    LessThan = 7,
    LessThanOrEqual = 8
}
export declare abstract class Sorting implements ISorting {
    columnName?: string | undefined;
    sortDirection?: SortDirection;
    constructor(data?: ISorting);
    toString: () => string;
    init(_data?: any): void;
    static fromJS(data: any): Sorting;
    toJSON(data?: any): any;
}
export interface ISorting {
    columnName?: string | undefined;
    sortDirection?: SortDirection;
}
export declare enum SortDirection {
    Ascending = 0,
    Descending = 1
}
export declare class OwnerRequest implements IOwnerRequest {
    personId?: string;
    unitId?: string;
    ownerTypeId?: string;
    constructor(data?: IOwnerRequest);
    init(_data?: any): void;
    static fromJS(data: any): OwnerRequest;
    toJSON(data?: any): any;
}
export interface IOwnerRequest {
    personId?: string;
    unitId?: string;
    ownerTypeId?: string;
}
export declare class PagedListResultOfOwnerType implements IPagedListResultOfOwnerType {
    items?: OwnerType[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfOwnerType);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfOwnerType;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfOwnerType {
    items?: OwnerType[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class OwnerTypeRequest implements IOwnerTypeRequest {
    name?: string | undefined;
    description?: string | undefined;
    constructor(data?: IOwnerTypeRequest);
    init(_data?: any): void;
    static fromJS(data: any): OwnerTypeRequest;
    toJSON(data?: any): any;
}
export interface IOwnerTypeRequest {
    name?: string | undefined;
    description?: string | undefined;
}
export declare class PagedListResultOfUnit implements IPagedListResultOfUnit {
    items?: Unit[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfUnit);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfUnit;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfUnit {
    items?: Unit[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class UnitRequest implements IUnitRequest {
    floor?: number;
    floorType?: FloorType;
    block?: string | undefined;
    blockDescription?: string | undefined;
    side?: string | undefined;
    code?: string | undefined;
    codePrefix?: string | undefined;
    codeSuffix?: string | undefined;
    unitTypeId?: string;
    constructor(data?: IUnitRequest);
    init(_data?: any): void;
    static fromJS(data: any): UnitRequest;
    toJSON(data?: any): any;
}
export interface IUnitRequest {
    floor?: number;
    floorType?: FloorType;
    block?: string | undefined;
    blockDescription?: string | undefined;
    side?: string | undefined;
    code?: string | undefined;
    codePrefix?: string | undefined;
    codeSuffix?: string | undefined;
    unitTypeId?: string;
}
export declare class UnitRangeRequest implements IUnitRangeRequest {
    floor?: number;
    floorType?: FloorType;
    block?: string | undefined;
    blockDescription?: string | undefined;
    side?: string | undefined;
    codeStart?: number;
    codeEnd?: number;
    codePrefix?: string | undefined;
    codeSuffix?: string | undefined;
    unitTypeId?: string;
    constructor(data?: IUnitRangeRequest);
    init(_data?: any): void;
    static fromJS(data: any): UnitRangeRequest;
    toJSON(data?: any): any;
}
export interface IUnitRangeRequest {
    floor?: number;
    floorType?: FloorType;
    block?: string | undefined;
    blockDescription?: string | undefined;
    side?: string | undefined;
    codeStart?: number;
    codeEnd?: number;
    codePrefix?: string | undefined;
    codeSuffix?: string | undefined;
    unitTypeId?: string;
}
export declare class PagedListResultOfUnitGroup implements IPagedListResultOfUnitGroup {
    items?: UnitGroup[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfUnitGroup);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfUnitGroup;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfUnitGroup {
    items?: UnitGroup[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class UnitGroupRequest implements IUnitGroupRequest {
    name?: string | undefined;
    constructor(data?: IUnitGroupRequest);
    init(_data?: any): void;
    static fromJS(data: any): UnitGroupRequest;
    toJSON(data?: any): any;
}
export interface IUnitGroupRequest {
    name?: string | undefined;
}
export declare class PagedListResultOfUnitType implements IPagedListResultOfUnitType {
    items?: UnitType[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfUnitType);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfUnitType;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfUnitType {
    items?: UnitType[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class UnitTypeRequest implements IUnitTypeRequest {
    name?: string | undefined;
    description?: string | undefined;
    constructor(data?: IUnitTypeRequest);
    init(_data?: any): void;
    static fromJS(data: any): UnitTypeRequest;
    toJSON(data?: any): any;
}
export interface IUnitTypeRequest {
    name?: string | undefined;
    description?: string | undefined;
}
export declare class MeetingSettings implements IMeetingSettings {
    creationEmailTemplate?: EmailTemplate | undefined;
    beforeNotificationEmailTemplate?: EmailTemplate | undefined;
    constructor(data?: IMeetingSettings);
    init(_data?: any): void;
    static fromJS(data: any): MeetingSettings;
    toJSON(data?: any): any;
}
export interface IMeetingSettings {
    creationEmailTemplate?: EmailTemplate | undefined;
    beforeNotificationEmailTemplate?: EmailTemplate | undefined;
}
export declare class EmailTemplate implements IEmailTemplate {
    id?: string;
    name?: string | undefined;
    code?: string | undefined;
    constructor(data?: IEmailTemplate);
    init(_data?: any): void;
    static fromJS(data: any): EmailTemplate;
    toJSON(data?: any): any;
}
export interface IEmailTemplate {
    id?: string;
    name?: string | undefined;
    code?: string | undefined;
}
export declare class MeetingSettingsRequest implements IMeetingSettingsRequest {
    creationEmailTemplateId?: string;
    beforeNotificationEmailTemplateId?: string;
    constructor(data?: IMeetingSettingsRequest);
    init(_data?: any): void;
    static fromJS(data: any): MeetingSettingsRequest;
    toJSON(data?: any): any;
}
export interface IMeetingSettingsRequest {
    creationEmailTemplateId?: string;
    beforeNotificationEmailTemplateId?: string;
}
export declare class PagedListResultOfPerson implements IPagedListResultOfPerson {
    items?: Person[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfPerson);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfPerson;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfPerson {
    items?: Person[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class AddressRequest implements IAddressRequest {
    address1?: string | undefined;
    address2?: string | undefined;
    addressNumber?: string | undefined;
    city?: string | undefined;
    state?: string | undefined;
    postalCode?: string | undefined;
    constructor(data?: IAddressRequest);
    init(_data?: any): void;
    static fromJS(data: any): AddressRequest;
    toJSON(data?: any): any;
}
export interface IAddressRequest {
    address1?: string | undefined;
    address2?: string | undefined;
    addressNumber?: string | undefined;
    city?: string | undefined;
    state?: string | undefined;
    postalCode?: string | undefined;
}
export declare class PersonRequest extends AddressRequest implements IPersonRequest {
    name?: string | undefined;
    email?: string | undefined;
    phoneNumber?: string | undefined;
    mobilePhoneNumber?: string | undefined;
    nickname?: string | undefined;
    taxNumber?: string | undefined;
    idNumber?: string | undefined;
    type?: PersonType;
    constructor(data?: IPersonRequest);
    init(_data?: any): void;
    static fromJS(data: any): PersonRequest;
    toJSON(data?: any): any;
}
export interface IPersonRequest extends IAddressRequest {
    name?: string | undefined;
    email?: string | undefined;
    phoneNumber?: string | undefined;
    mobilePhoneNumber?: string | undefined;
    nickname?: string | undefined;
    taxNumber?: string | undefined;
    idNumber?: string | undefined;
    type?: PersonType;
}
export declare class PersonUnitRequest implements IPersonUnitRequest {
    unitId?: string;
    ownerTypeId?: string;
    constructor(data?: IPersonUnitRequest);
    init(_data?: any): void;
    static fromJS(data: any): PersonUnitRequest;
    toJSON(data?: any): any;
}
export interface IPersonUnitRequest {
    unitId?: string;
    ownerTypeId?: string;
}
export declare class Document implements IDocument {
    constructor(data?: IDocument);
    init(_data?: any): void;
    static fromJS(data: any): Document;
    toJSON(data?: any): any;
}
export interface IDocument {
}
export declare class PagedListResultOfDocument implements IPagedListResultOfDocument {
    items?: Document[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfDocument);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfDocument;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfDocument {
    items?: Document[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class DocumentRequest implements IDocumentRequest {
    constructor(data?: IDocumentRequest);
    init(_data?: any): void;
    static fromJS(data: any): DocumentRequest;
    toJSON(data?: any): any;
}
export interface IDocumentRequest {
}
export declare class Meeting implements IMeeting {
    id?: string;
    name?: string | undefined;
    description?: string | undefined;
    type?: MeetingType | undefined;
    startsOn?: moment.Moment | undefined;
    endsOn?: moment.Moment | undefined;
    statusCode?: MeetingStatus;
    constructor(data?: IMeeting);
    init(_data?: any): void;
    static fromJS(data: any): Meeting;
    toJSON(data?: any): any;
}
export interface IMeeting {
    id?: string;
    name?: string | undefined;
    description?: string | undefined;
    type?: MeetingType | undefined;
    startsOn?: moment.Moment | undefined;
    endsOn?: moment.Moment | undefined;
    statusCode?: MeetingStatus;
}
export declare class MeetingType extends AuditMetadata implements IMeetingType {
    id?: string;
    name?: string | undefined;
    description?: string | undefined;
    constructor(data?: IMeetingType);
    init(_data?: any): void;
    static fromJS(data: any): MeetingType;
    toJSON(data?: any): any;
}
export interface IMeetingType extends IAuditMetadata {
    id?: string;
    name?: string | undefined;
    description?: string | undefined;
}
export declare enum MeetingStatus {
    Created = 0
}
export declare class PagedListResultOfMeeting implements IPagedListResultOfMeeting {
    items?: Meeting[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfMeeting);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfMeeting;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfMeeting {
    items?: Meeting[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class MeetingRequest implements IMeetingRequest {
    name?: string | undefined;
    description?: string | undefined;
    meetingTypeId?: string;
    startsOn?: moment.Moment;
    endsOn?: moment.Moment;
    statusCode?: MeetingStatus;
    constructor(data?: IMeetingRequest);
    init(_data?: any): void;
    static fromJS(data: any): MeetingRequest;
    toJSON(data?: any): any;
}
export interface IMeetingRequest {
    name?: string | undefined;
    description?: string | undefined;
    meetingTypeId?: string;
    startsOn?: moment.Moment;
    endsOn?: moment.Moment;
    statusCode?: MeetingStatus;
}
export declare class PagedListResultOfMeetingType implements IPagedListResultOfMeetingType {
    items?: MeetingType[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfMeetingType);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfMeetingType;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfMeetingType {
    items?: MeetingType[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class MeetingTypeRequest implements IMeetingTypeRequest {
    name?: string | undefined;
    description?: string | undefined;
    constructor(data?: IMeetingTypeRequest);
    init(_data?: any): void;
    static fromJS(data: any): MeetingTypeRequest;
    toJSON(data?: any): any;
}
export interface IMeetingTypeRequest {
    name?: string | undefined;
    description?: string | undefined;
}
export declare class MeetingUnit implements IMeetingUnit {
    constructor(data?: IMeetingUnit);
    init(_data?: any): void;
    static fromJS(data: any): MeetingUnit;
    toJSON(data?: any): any;
}
export interface IMeetingUnit {
}
export declare class PagedListResultOfMeetingUnit implements IPagedListResultOfMeetingUnit {
    items?: MeetingUnit[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfMeetingUnit);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfMeetingUnit;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfMeetingUnit {
    items?: MeetingUnit[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class MeetingUnitRequest implements IMeetingUnitRequest {
    constructor(data?: IMeetingUnitRequest);
    init(_data?: any): void;
    static fromJS(data: any): MeetingUnitRequest;
    toJSON(data?: any): any;
}
export interface IMeetingUnitRequest {
}
export declare class VotingSession implements IVotingSession {
    id?: string;
    description?: string | undefined;
    order?: number;
    startsOn?: moment.Moment;
    endsOn?: moment.Moment;
    constructor(data?: IVotingSession);
    init(_data?: any): void;
    static fromJS(data: any): VotingSession;
    toJSON(data?: any): any;
}
export interface IVotingSession {
    id?: string;
    description?: string | undefined;
    order?: number;
    startsOn?: moment.Moment;
    endsOn?: moment.Moment;
}
export declare class PagedListResultOfVotingSession implements IPagedListResultOfVotingSession {
    items?: VotingSession[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfVotingSession);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfVotingSession;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfVotingSession {
    items?: VotingSession[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class VotingSessionRequest implements IVotingSessionRequest {
    startsOn?: moment.Moment;
    endsOn?: moment.Moment;
    constructor(data?: IVotingSessionRequest);
    init(_data?: any): void;
    static fromJS(data: any): VotingSessionRequest;
    toJSON(data?: any): any;
}
export interface IVotingSessionRequest {
    startsOn?: moment.Moment;
    endsOn?: moment.Moment;
}
export declare class VotingTopic implements IVotingTopic {
    constructor(data?: IVotingTopic);
    init(_data?: any): void;
    static fromJS(data: any): VotingTopic;
    toJSON(data?: any): any;
}
export interface IVotingTopic {
}
export declare class PagedListResultOfVotingTopic implements IPagedListResultOfVotingTopic {
    items?: VotingTopic[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfVotingTopic);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfVotingTopic;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfVotingTopic {
    items?: VotingTopic[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class VotingTopicRequest implements IVotingTopicRequest {
    constructor(data?: IVotingTopicRequest);
    init(_data?: any): void;
    static fromJS(data: any): VotingTopicRequest;
    toJSON(data?: any): any;
}
export interface IVotingTopicRequest {
}
export declare class VotingTopicOption implements IVotingTopicOption {
    constructor(data?: IVotingTopicOption);
    init(_data?: any): void;
    static fromJS(data: any): VotingTopicOption;
    toJSON(data?: any): any;
}
export interface IVotingTopicOption {
}
export declare class PagedListResultOfVotingTopicOption implements IPagedListResultOfVotingTopicOption {
    items?: VotingTopicOption[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfVotingTopicOption);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfVotingTopicOption;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfVotingTopicOption {
    items?: VotingTopicOption[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class VotingTopicOptionRequest implements IVotingTopicOptionRequest {
    constructor(data?: IVotingTopicOptionRequest);
    init(_data?: any): void;
    static fromJS(data: any): VotingTopicOptionRequest;
    toJSON(data?: any): any;
}
export interface IVotingTopicOptionRequest {
}
export declare class PagedListResultOfEmailTemplate implements IPagedListResultOfEmailTemplate {
    items?: EmailTemplate[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
    constructor(data?: IPagedListResultOfEmailTemplate);
    init(_data?: any): void;
    static fromJS(data: any): PagedListResultOfEmailTemplate;
    toJSON(data?: any): any;
}
export interface IPagedListResultOfEmailTemplate {
    items?: EmailTemplate[] | undefined;
    pageIndex?: number;
    pageSize?: number;
    totalCount?: number;
}
export declare class EmailTemplateRequest implements IEmailTemplateRequest {
    name?: string | undefined;
    code?: string | undefined;
    constructor(data?: IEmailTemplateRequest);
    init(_data?: any): void;
    static fromJS(data: any): EmailTemplateRequest;
    toJSON(data?: any): any;
}
export interface IEmailTemplateRequest {
    name?: string | undefined;
    code?: string | undefined;
}
export declare class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: {
        [key: string]: any;
    };
    result: any;
    constructor(message: string, status: number, response: string, headers: {
        [key: string]: any;
    }, result: any);
    protected isApiException: boolean;
    static isApiException(obj: any): obj is ApiException;
}
