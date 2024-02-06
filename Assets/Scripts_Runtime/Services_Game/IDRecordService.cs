namespace Ping {

    public class IDRecordService {

        int paddleEntityID;

        public IDRecordService() { }

        public int PickPaddleEntityID() {
            return ++paddleEntityID;
        }

        public void Reset() {
            paddleEntityID = 0;
        }
    }

}